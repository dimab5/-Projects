using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.SelectUserMode;

public class SelectUserModeScenario : IScenario
{
    private readonly IUserService _userService;

    public SelectUserModeScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Select User Mode";

    public void Run()
    {
        _userService.UserLogin();

        string message = "Successful select User mode";
        AnsiConsole.WriteLine(message + '\n');
    }
}