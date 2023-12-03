using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp.Directors;

public class StandartXmpBuilderDirector : IXmpBuilderDirector
{
    public IXmpProfileBuilder Direct(IXmpProfileBuilder xmpProfileBuilder)
    {
        xmpProfileBuilder
            .WithFrequency(100)
            .WithTimings(new List<int> { 10, 20, 30 })
            .WithVoltage(1000);

        return xmpProfileBuilder;
    }
}