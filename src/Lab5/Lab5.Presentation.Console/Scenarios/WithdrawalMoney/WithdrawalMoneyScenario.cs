using Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.WithdrawalMoney;

public class WithdrawalMoneyScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public WithdrawalMoneyScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Withdrawal money";

    public void Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter amount");

        WithdrawalResult result = _bankAccountService.WithdrawMoney(amount);

        string message = result switch
        {
            WithdrawalResult.Success => "Successful withdrawal money",
            WithdrawalResult.NotEnoughMoney => "Not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message + '\n');
    }
}