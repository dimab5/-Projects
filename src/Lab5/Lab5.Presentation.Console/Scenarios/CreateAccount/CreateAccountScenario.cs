using Application.Contracts.BankAccounts;
using Application.Contracts.OperationHistories;
using Spectre.Console;

namespace Presentation.Console.Scenarios.CreateAccount;

public class CreateAccountScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public CreateAccountScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Create new Bank Account";

    public void Run()
    {
        string? accountNumber = AnsiConsole.Ask<string>("Enter account number");
        string pinCode = AnsiConsole.Ask<string>("Enter pin-code");

        OperationResult result = _bankAccountService.CreateBankAccount(accountNumber, pinCode);

        string message = result switch
        {
            OperationResult.Success => "Successful create account",
            OperationResult.Fail => "Fail",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message + '\n');
    }
}