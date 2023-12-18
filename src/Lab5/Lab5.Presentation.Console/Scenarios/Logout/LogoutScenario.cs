using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.Logout;

public class LogoutScenario : IScenario
{
    private readonly IUserService _userService;

    public LogoutScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Logout";

    public void Run()
    {
        _userService.Logout();

        string message = "Successful login";

        AnsiConsole.WriteLine(message + '\n');
    }
}