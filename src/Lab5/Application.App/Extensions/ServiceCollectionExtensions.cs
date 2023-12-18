using Application.App.BankAccounts;
using Application.App.Users;
using Application.Contracts.BankAccounts;
using Application.Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IBankAccountService, BankAccountService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        collection.AddScoped<CurrentAccountManager>();
        collection.AddScoped<ICurrentAccountService>(
            p => p.GetRequiredService<CurrentAccountManager>());

        return collection;
    }
}