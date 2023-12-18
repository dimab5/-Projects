using Application.Models.Users;

namespace Application.Models.BankAccounts;

public record Account(
    long UserId,
    long Amount,
    string AccountNumber,
    string PinCode,
    UserRole UserAccessRole);