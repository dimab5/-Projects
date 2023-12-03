using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PassageRoute;

public abstract record PossibleResults
{
    private PossibleResults()
    {
    }

    public sealed record Success(decimal Time, IReadOnlyList<IFuel> Fuels) : PossibleResults;

    public sealed record Fail() : PossibleResults;
}