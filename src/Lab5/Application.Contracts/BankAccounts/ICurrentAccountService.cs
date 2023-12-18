using Application.Models.BankAccounts;

namespace Application.Contracts.BankAccounts;

public interface ICurrentAccountService
{
    BankAccount? BankAccount { get; }
}