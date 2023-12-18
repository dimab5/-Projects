using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Application.Models.Users;

namespace Presentation.Console.Scenarios.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public LoginScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null || _currentUser?.User?.Role == UserRole.Undefined)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginScenario(_service);
        return true;
    }
}