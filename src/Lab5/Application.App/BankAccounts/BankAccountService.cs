using Application.Abstractions.Repositories;
using Application.App.Users;
using Application.Contracts.BankAccounts;
using Application.Contracts.OperationHistories;
using Application.Models.BankAccounts;
using Application.Models.OperationHistories;
using Application.Models.Users;

namespace Application.App.BankAccounts;

public class BankAccountService : IBankAccountService
{
    private readonly CurrentUserManager _currentUserManager;
    private readonly CurrentAccountManager _currentAccountManager;
    private readonly IAccountRepository _accountRepository;
    private readonly IOperationHistoryRepository _operationHistoryRepository;

    public BankAccountService(
        CurrentUserManager currentUserManager,
        CurrentAccountManager currentAccountManager,
        IAccountRepository accountRepository,
        IOperationHistoryRepository operationHistoryRepository)
    {
        _currentUserManager = currentUserManager;
        _currentAccountManager = currentAccountManager;
        _accountRepository = accountRepository;
        _operationHistoryRepository = operationHistoryRepository;
    }

    public BankAccountLoginResult LoginBankAccount(string accountNumber, string pinCode)
    {
        BankAccount? bankAccount = _accountRepository.FindAccountByNumber(accountNumber).Result;

        if (bankAccount == null ||
            bankAccount.UserId != _currentUserManager.User?.Id ||
            (bankAccount.UserAccessRole != _currentUserManager.User.Role && _currentUserManager.User.Role != UserRole.Admin))
        {
            LogLoginAttempt(accountNumber, OperationResult.Fail);
            return bankAccount == null ? new BankAccountLoginResult.AccountNotFound()
                : new BankAccountLoginResult.WrongNumberOrPincode();
        }

        if (bankAccount.PinCode != pinCode)
        {
            LogLoginAttempt(accountNumber, OperationResult.Fail);
            return new BankAccountLoginResult.WrongNumberOrPincode();
        }

        LogLoginAttempt(accountNumber, OperationResult.Success);
        _currentAccountManager.BankAccount = bankAccount;
        return new BankAccountLoginResult.Success();
    }

    public OperationResult CreateBankAccount(string accountNumber, string pinCode)
    {
        if (_currentUserManager.User != null)
        {
            Task.Run(async () =>
            {
                await _accountRepository.CreateAccount(
                    new Account(
                        _currentUserManager.User.Id,
                        0,
                        accountNumber,
                        pinCode,
                        _currentUserManager.User.Role)).ConfigureAwait(false);

                if (_currentUserManager.User != null)
                {
                    string action = $"Create bank account {accountNumber}";

                    await _operationHistoryRepository.AddOperationInHistory(new Operation(
                        _currentUserManager.User.Username,
                        accountNumber,
                        action,
                        OperationResult.Success)).ConfigureAwait(false);
                }
            }).GetAwaiter().GetResult();
        }

        return OperationResult.Success;
    }

    public BankAccount? ViewAccountBalance()
    {
        return _currentAccountManager.BankAccount;
    }

    public WithdrawalResult WithdrawMoney(long amount)
    {
        if (_currentUserManager.User is null || _currentAccountManager.BankAccount is null)
        {
            return new WithdrawalResult.NotEnoughMoney();
        }

        string action = $"-{amount}";

        var operation = new Operation(
            _currentUserManager.User.Username,
            _currentAccountManager.BankAccount.AccountNumber,
            action,
            OperationResult.Fail);

        if (_currentAccountManager.BankAccount.Amount < amount)
        {
            Task.Run(async () =>
            {
                await _operationHistoryRepository.AddOperationInHistory(operation).ConfigureAwait(false);
            }).GetAwaiter().GetResult();

            return new WithdrawalResult.NotEnoughMoney();
        }

        _currentAccountManager.BankAccount = _currentAccountManager.BankAccount
            with { Amount = _currentAccountManager.BankAccount.Amount - amount };

        long moneyAmount = _currentAccountManager.BankAccount.Amount;

        Task.Run(async () =>
        {
            await _accountRepository.ChangeAmounMoney(
                _currentAccountManager.BankAccount.AccountNumber,
                moneyAmount).ConfigureAwait(false);

            await _operationHistoryRepository.AddOperationInHistory(operation
                with { Result = OperationResult.Success }).ConfigureAwait(false);
        }).GetAwaiter().GetResult();

        return new WithdrawalResult.Success();
    }

    public OperationResult DepositMoney(long amount)
    {
        if (_currentAccountManager.BankAccount is null)
        {
            return OperationResult.Fail;
        }

        _currentAccountManager.BankAccount = _currentAccountManager.BankAccount
            with { Amount = _currentAccountManager.BankAccount.Amount + amount };

        long moneyAmount = _currentAccountManager.BankAccount.Amount;

        Task.Run(async () =>
        {
            await _accountRepository.ChangeAmounMoney(
                _currentAccountManager.BankAccount.AccountNumber,
                moneyAmount).ConfigureAwait(false);

            if (_currentUserManager.User != null)
            {
                string action = $"+{amount}";

                await _operationHistoryRepository.AddOperationInHistory(new Operation(
                    _currentUserManager.User.Username,
                    _currentAccountManager.BankAccount.AccountNumber,
                    action,
                    OperationResult.Success)).ConfigureAwait(false);
            }
        }).GetAwaiter().GetResult();

        return OperationResult.Success;
    }

    public void LogoutBankAccount()
    {
        if (_currentUserManager.User != null && _currentAccountManager.BankAccount?.AccountNumber != null)
        {
            string action = $"Logout bank account {_currentAccountManager.BankAccount.AccountNumber}";

            _operationHistoryRepository.AddOperationInHistory(new Operation(
                _currentUserManager.User.Username,
                _currentAccountManager.BankAccount.AccountNumber,
                action,
                OperationResult.Success)).ConfigureAwait(false);
        }

        _currentAccountManager.BankAccount = null;
    }

    private void LogLoginAttempt(string accountNumber, OperationResult result)
    {
        if (_currentUserManager.User != null)
        {
            string action = $"Login bank account {accountNumber}";
            _operationHistoryRepository.AddOperationInHistory(new Operation(
                _currentUserManager.User.Username,
                accountNumber,
                action,
                result)).ConfigureAwait(false);
        }
    }
}