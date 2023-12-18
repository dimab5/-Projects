using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.SelectAdminMode;

public class SelectAdminModeScenario : IScenario
{
    private readonly IUserService _userService;

    public SelectAdminModeScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Select Admin Mode";

    public void Run()
    {
        long password = AnsiConsole.Ask<long>("Enter password");

        AdminLoginResult result = _userService.AdminLogin(password);

        string message = result switch
        {
            AdminLoginResult.Success => "Successful select Admin mode",
            AdminLoginResult.WrongPassword => "Wrong Password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message + '\n');
    }
}