using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler.Directors;

public class StandartCoolingSystemBuilderDirector : ICoolingSystemBuilderDirector
{
    public ICoolingSystemBuilder Direct(ICoolingSystemBuilder coolingSystemBuilder)
    {
        coolingSystemBuilder
            .WithDimensions(new Dimensions(5, 10, 20))
            .WithSupportedSockets(new List<Socket> { new Socket("LGA 1200") })
            .WithTdp(1000);

        return coolingSystemBuilder;
    }
}