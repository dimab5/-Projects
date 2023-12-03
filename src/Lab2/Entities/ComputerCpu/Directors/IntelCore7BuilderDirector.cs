using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu.Directors;

public class IntelCore7BuilderDirector : IComputerCpuBuilderDirector
{
    public ICpuBuilder Direct(ICpuBuilder cpuBuilder)
    {
        cpuBuilder
            .WithCoreFrequency(3400)
            .WithCoreCount(8)
            .WithCpuSocket(new Socket("LGA 1200"))
            .WithEmbeddedCore(true)
            .WithMemoryFrequencies(new List<int> { 3400, 4500 })
            .WithHeatDissipation(105)
            .WithPowerConsumption(100);

        return cpuBuilder;
    }
}