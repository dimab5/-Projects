namespace Application.Contracts.BankAccounts;

public record WithdrawalResult
{
    protected WithdrawalResult() { }

    public sealed record Success : WithdrawalResult;

    public sealed record NotEnoughMoney : WithdrawalResult;
}