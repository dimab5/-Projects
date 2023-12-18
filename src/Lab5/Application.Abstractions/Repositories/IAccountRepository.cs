using Application.Models.BankAccounts;

namespace Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Task<BankAccount?> FindAccountByNumber(string? accountNumber);
    Task CreateAccount(Account bankAccount);
    Task ChangeAmounMoney(string? accountNumber, long amount);
}