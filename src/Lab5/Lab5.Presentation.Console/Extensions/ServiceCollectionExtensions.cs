using Microsoft.Extensions.DependencyInjection;
using Presentation.Console.Scenarios;
using Presentation.Console.Scenarios.AccountLoginScenario;
using Presentation.Console.Scenarios.AccountLogoutScenario;
using Presentation.Console.Scenarios.CreateAccount;
using Presentation.Console.Scenarios.DepositMoney;
using Presentation.Console.Scenarios.Login;
using Presentation.Console.Scenarios.Logout;
using Presentation.Console.Scenarios.Registration;
using Presentation.Console.Scenarios.SelectAdminMode;
using Presentation.Console.Scenarios.SelectUserMode;
using Presentation.Console.Scenarios.ViewAccountBalance;
using Presentation.Console.Scenarios.ViewOperationHistory;
using Presentation.Console.Scenarios.WithdrawalMoney;

namespace Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegistrationScenarioProvider>();
        collection.AddScoped<IScenarioProvider, SelectAdminModeScenarioProvider>();
        collection.AddScoped<IScenarioProvider, SelectUserModeScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewOperationHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AccountLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewAccountBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawalMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AccountLogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutScenarioProvider>();

        return collection;
    }
}