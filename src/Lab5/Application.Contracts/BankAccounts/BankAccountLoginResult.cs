namespace Application.Contracts.BankAccounts;

public record BankAccountLoginResult
{
    protected BankAccountLoginResult() { }

    public sealed record Success : BankAccountLoginResult;

    public sealed record AccountNotFound : BankAccountLoginResult;

    public sealed record WrongNumberOrPincode : BankAccountLoginResult;
}