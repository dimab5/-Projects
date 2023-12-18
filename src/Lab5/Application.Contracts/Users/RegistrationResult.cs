namespace Application.Contracts.Users;

public abstract record RegistrationResult
{
    protected RegistrationResult() { }

    public sealed record Success : RegistrationResult;

    public sealed record Fail : RegistrationResult;
}