using Application.Contracts.BankAccounts;
using Application.Contracts.OperationHistories;
using Spectre.Console;

namespace Presentation.Console.Scenarios.DepositMoney;

public class DepositMoneyScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public DepositMoneyScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Deposit money";

    public void Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter amount");

        OperationResult result = _bankAccountService.DepositMoney(amount);

        string message = result switch
        {
            OperationResult.Success => "Successful deposit money",
            OperationResult.Fail => "Fail",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message + '\n');
    }
}