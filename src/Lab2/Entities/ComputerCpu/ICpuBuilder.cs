using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;

public interface ICpuBuilder
{
    ICpuBuilder WithCoreFrequency(int coreFrequency);
    ICpuBuilder WithCoreCount(int coreCount);
    ICpuBuilder WithCpuSocket(Socket? cpuSocket);
    ICpuBuilder WithEmbeddedCore(bool existEmbeddedCore);
    ICpuBuilder WithMemoryFrequencies(IReadOnlyList<int>? supportedMemoryFrequencies);
    ICpuBuilder WithHeatDissipation(int heatDissipation);
    ICpuBuilder WithPowerConsumption(int powerConsumption);
    ICpu Build();
}