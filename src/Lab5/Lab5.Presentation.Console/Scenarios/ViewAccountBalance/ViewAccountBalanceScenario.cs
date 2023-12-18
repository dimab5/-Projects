using Application.Contracts.BankAccounts;
using Application.Models.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.ViewAccountBalance;

public class ViewAccountBalanceScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public ViewAccountBalanceScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "View Account balance";

    public void Run()
    {
        BankAccount? bankAccount = _bankAccountService.ViewAccountBalance();

        long? message = bankAccount?.Amount;

        AnsiConsole.WriteLine($"{message}\n");
    }
}