using System.Diagnostics.CodeAnalysis;
using Application.Contracts.BankAccounts;
using Application.Contracts.Users;
using Application.Models.Users;

namespace Presentation.Console.Scenarios.CreateAccount;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentUserService _currentUser;
    private readonly ICurrentAccountService _accountService;

    public CreateAccountScenarioProvider(
        ICurrentUserService currentUser,
        IBankAccountService bankAccountService,
        ICurrentAccountService accountService)
    {
        _currentUser = currentUser;
        _service = bankAccountService;
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null
            || _currentUser?.User?.Role == UserRole.Undefined
            || _accountService.BankAccount is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateAccountScenario(_service);
        return true;
    }
}