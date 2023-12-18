using System.Diagnostics.CodeAnalysis;
using Application.Contracts.BankAccounts;
using Application.Contracts.Users;
using Application.Models.Users;

namespace Presentation.Console.Scenarios.AccountLogoutScenario;

public class AccountLogoutScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentUserService _currentUser;
    private readonly ICurrentAccountService _currentAccount;

    public AccountLogoutScenarioProvider(
        ICurrentUserService currentUser,
        IBankAccountService bankAccountService,
        ICurrentAccountService currentAccount)
    {
        _currentUser = currentUser;
        _service = bankAccountService;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null
            || _currentUser?.User?.Role == UserRole.Undefined
            || _currentAccount.BankAccount is null)
        {
            scenario = null;
            return false;
        }

        scenario = new AccountLogoutScenario(_service);
        return true;
    }
}