using System.Collections.ObjectModel;
using Application.Contracts.Users;
using Application.Models.OperationHistories;
using Spectre.Console;

namespace Presentation.Console.Scenarios.ViewOperationHistory;

public class ViewOperationHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public ViewOperationHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "View Operation History";

    public void Run()
    {
        ReadOnlyCollection<OperationHistory?> operationHistory = _userService.ViewOperationHistory();

        AnsiConsole.WriteLine("Operation History:");

        foreach (OperationHistory? history in operationHistory)
        {
            AnsiConsole.WriteLine(
                $"{history?.Username} - {history?.AccountNumber} - {history?.Action} - {history?.Result}");
        }

        AnsiConsole.WriteLine();
    }
}