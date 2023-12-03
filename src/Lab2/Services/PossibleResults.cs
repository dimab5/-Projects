namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public record PossibleResults
{
    public sealed record Success() : PossibleResults;

    public sealed record SuccessWithComments(string Comments) : PossibleResults;

    public sealed record Fail(string Comments) : PossibleResults;
}