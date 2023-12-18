using Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.AccountLogoutScenario;

public class AccountLogoutScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public AccountLogoutScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Logout Bank Account";

    public void Run()
    {
        _bankAccountService.LogoutBankAccount();
        string message = "You successfully logout";

        AnsiConsole.WriteLine(message + '\n');
    }
}