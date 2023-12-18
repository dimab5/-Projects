using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;

namespace Presentation.Console.Scenarios.ViewOperationHistory;

public class ViewOperationHistoryScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public ViewOperationHistoryScenarioProvider(
        ICurrentUserService currentUser,
        IUserService userService)
    {
        _currentUser = currentUser;
        _userService = userService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ViewOperationHistoryScenario(_userService);
        return true;
    }
}