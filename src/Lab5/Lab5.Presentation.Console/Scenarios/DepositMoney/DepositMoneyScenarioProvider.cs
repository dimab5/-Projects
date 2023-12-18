using System.Diagnostics.CodeAnalysis;
using Application.Contracts.BankAccounts;
using Application.Contracts.Users;
using Application.Models.Users;

namespace Presentation.Console.Scenarios.DepositMoney;

public class DepositMoneyScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAccountService _currentAccount;
    private readonly ICurrentUserService _currentUser;
    private readonly IBankAccountService _service;

    public DepositMoneyScenarioProvider(
        ICurrentUserService currentUser,
        ICurrentAccountService accountService,
        IBankAccountService service)
    {
        _currentAccount = accountService;
        _service = service;
        _currentUser = currentUser;
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

        scenario = new DepositMoneyScenario(_service);
        return true;
    }
}