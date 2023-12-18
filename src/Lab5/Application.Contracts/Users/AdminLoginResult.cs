namespace Application.Contracts.Users;

public record AdminLoginResult
{
    protected AdminLoginResult() { }

    public sealed record Success : AdminLoginResult;

    public sealed record WrongPassword : AdminLoginResult;
}