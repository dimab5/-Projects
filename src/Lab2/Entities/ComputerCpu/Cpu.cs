using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;

public class Cpu : ICpu
{
    public Cpu(
        int coreFrequency,
        int coreCount,
        Socket cpuSocket,
        bool embeddedCore,
        IReadOnlyList<int> memoryFrequencies,
        int heatDissipation,
        int powerConsumption)
    {
        СoreFrequency = coreFrequency;
        CoreCount = coreCount;
        CpuSocket = cpuSocket;
        EmbeddedCore = embeddedCore;
        SupportedMemoryFrequencies = memoryFrequencies;
        HeatDissipation = heatDissipation;
        PowerConsumption = powerConsumption;
    }

    public int СoreFrequency { get; }
    public int CoreCount { get; }
    public Socket CpuSocket { get; }
    public bool EmbeddedCore { get; }
    public IReadOnlyList<int> SupportedMemoryFrequencies { get; }
    public int HeatDissipation { get; }
    public int PowerConsumption { get; }

    public PossibleResults? Validate(ISystemBlock systemBlock)
    {
        string result = string.Empty;

        if (HeatDissipation > (systemBlock.Cooler?.Tdp ?? 0))
        {
            result += "Insufficient CPU cooling system. Disclaimer of warranty obligations.\n";
        }

        if (string.IsNullOrEmpty(result))
        {
            return new PossibleResults.Success();
        }

        return new PossibleResults.SuccessWithComments(result);
    }

    public ICpuBuilder Direct(ICpuBuilder cpuBuilder)
    {
        cpuBuilder
            .WithCoreFrequency(СoreFrequency)
            .WithCoreCount(CoreCount)
            .WithCpuSocket(CpuSocket)
            .WithEmbeddedCore(EmbeddedCore)
            .WithMemoryFrequencies(SupportedMemoryFrequencies)
            .WithHeatDissipation(HeatDissipation)
            .WithPowerConsumption(PowerConsumption);

        return cpuBuilder;
    }
}