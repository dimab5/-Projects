namespace Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

public abstract record OperationResult(string Message)
{
    public sealed record Success(string Message) : OperationResult(Message);

    public sealed record Fail(string Message) : OperationResult(Message);
}