using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public static class SuccessfulComputerAssemblyWithWarning
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new StandartSystemBlockBuilderDirector().Direct(new SystemBlockBuilder()),
                new PossibleResults.SuccessWithComments("Insufficient power of the power supply.\n"),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public static void ComputerBuildShouldReturnSuccessWithWarning(ISystemBlockBuilder systemBlock, PossibleResults? expectedResult)
    {
        ISystemBlockBuilder builder = systemBlock.WithPowerBlock(new PowerBlockClass(100));
        builder.Build();

        PossibleResults? result = builder.BuildResult;

        Assert.Equal(result, expectedResult);
    }
}