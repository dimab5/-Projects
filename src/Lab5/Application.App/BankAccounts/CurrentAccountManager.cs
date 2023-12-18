using Application.Contracts.BankAccounts;
using Application.Models.BankAccounts;

namespace Application.App.BankAccounts;

public class CurrentAccountManager : ICurrentAccountService
{
    public BankAccount? BankAccount { get; set; }
}