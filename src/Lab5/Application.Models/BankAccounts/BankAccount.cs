using Application.Models.Users;

namespace Application.Models.BankAccounts;

public record BankAccount(
    long BankAccountId,
    long UserId,
    long Amount,
    string AccountNumber,
    string PinCode,
    UserRole UserAccessRole);