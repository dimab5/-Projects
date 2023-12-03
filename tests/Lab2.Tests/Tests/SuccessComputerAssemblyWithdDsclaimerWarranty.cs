using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public static class SuccessComputerAssemblyWithdDsclaimerWarranty
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new StandartSystemBlockBuilderDirector().Direct(new SystemBlockBuilder()),
                new PossibleResults.SuccessWithComments(
                    "Insufficient CPU cooling system. Disclaimer of warranty obligations.\n"),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public static void ComputerBuildShouldReturnSuccessWithWarning(ISystemBlockBuilder systemBlock, PossibleResults? expectedResult)
    {
        ISystemBlockBuilder builder = systemBlock.WithCooler(
            new CoolingSystem(
                new Dimensions(1, 2, 3),
                new List<Socket> { new Socket("LGA 1200") },
                10));
        builder.Build();

        PossibleResults? result = builder.BuildResult;

        Assert.Equal(result, expectedResult);
    }
}