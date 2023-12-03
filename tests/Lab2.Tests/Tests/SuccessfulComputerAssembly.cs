using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public static class SuccessfulComputerAssembly
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new StandartSystemBlockBuilderDirector().Direct(new SystemBlockBuilder()),
                new PossibleResults.Success(),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public static void ComputerBuildShouldReturnSuccess(ISystemBlockBuilder systemBlock, PossibleResults? expectedResult)
    {
        ISystemBlockBuilder builder = systemBlock;
        builder.Build();

        PossibleResults? result = builder.BuildResult;

        Assert.Equal(result, expectedResult);
    }
}
