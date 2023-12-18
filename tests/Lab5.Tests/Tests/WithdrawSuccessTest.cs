using Application.Abstractions.Repositories;
using Application.App.BankAccounts;
using Application.App.Users;
using Application.Contracts.BankAccounts;
using Application.Models.BankAccounts;
using Application.Models.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Tests;

public static class WithdrawSuccessTest
{
    [Fact]
    public static void WithdrawMoney_ShouldReturnSuccess()
    {
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IOperationHistoryRepository operationHistoryRepository =
            Substitute.For<IOperationHistoryRepository>();

        var currentUserManager = new CurrentUserManager();
        currentUserManager.User = new User(123, "dima", UserRole.User);

        var currentAccountManager = new CurrentAccountManager();
        currentAccountManager.BankAccount = new BankAccount(
            12345, 123, 50, "1", "1", UserRole.User);

        IBankAccountService bankAccountService = new BankAccountService(
            currentUserManager,
            currentAccountManager,
            accountRepository,
            operationHistoryRepository);

        Assert.Equal(bankAccountService.WithdrawMoney(10), new WithdrawalResult.Success());
    }
}