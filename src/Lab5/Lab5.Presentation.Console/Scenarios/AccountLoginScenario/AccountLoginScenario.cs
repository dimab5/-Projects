using Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.AccountLoginScenario;

public class AccountLoginScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public AccountLoginScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Login Bank Account";

    public void Run()
    {
        string accountNumber = AnsiConsole.Ask<string>("Enter account number");
        string pinCode = AnsiConsole.Ask<string>("Enter pin-code");

        BankAccountLoginResult result = _bankAccountService.LoginBankAccount(accountNumber, pinCode);

        string message = result switch
        {
            BankAccountLoginResult.Success => "Successful login account",
            BankAccountLoginResult.WrongNumberOrPincode => "Wrong Number or Pin-code",
            BankAccountLoginResult.AccountNotFound => "Account not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message + '\n');
    }
}