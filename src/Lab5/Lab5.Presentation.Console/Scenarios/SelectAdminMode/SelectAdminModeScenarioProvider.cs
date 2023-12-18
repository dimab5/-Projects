using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Application.Models.Users;

namespace Presentation.Console.Scenarios.SelectAdminMode;

public class SelectAdminModeScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public SelectAdminModeScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null || _currentUser?.User?.Role == UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new SelectAdminModeScenario(_service);
        return true;
    }
}