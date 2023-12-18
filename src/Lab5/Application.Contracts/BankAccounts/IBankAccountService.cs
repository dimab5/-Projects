using Application.Contracts.OperationHistories;
using Application.Models.BankAccounts;

namespace Application.Contracts.BankAccounts;

public interface IBankAccountService
{
    BankAccountLoginResult LoginBankAccount(string accountNumber, string pinCode);
    OperationResult CreateBankAccount(string accountNumber, string pinCode);
    BankAccount? ViewAccountBalance();
    WithdrawalResult WithdrawMoney(long amount);
    OperationResult DepositMoney(long amount);
    void LogoutBankAccount();
}