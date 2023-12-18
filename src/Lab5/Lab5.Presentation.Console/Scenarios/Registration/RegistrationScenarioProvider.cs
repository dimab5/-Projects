using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Application.Models.Users;

namespace Presentation.Console.Scenarios.Registration;

public class RegistrationScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public RegistrationScenarioProvider(
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

        scenario = new RegistrationScenario(_service);
        return true;
    }
}