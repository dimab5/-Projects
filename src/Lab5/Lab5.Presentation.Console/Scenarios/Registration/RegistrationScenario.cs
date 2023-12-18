using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.Registration;

public class RegistrationScenario : IScenario
{
    private readonly IUserService _userService;

    public RegistrationScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Registration";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");

        RegistrationResult result = _userService.Registration(username);

        string message = result switch
        {
            RegistrationResult.Success => "Successful registration",
            RegistrationResult.Fail => "Fail",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message + '\n');
    }
}