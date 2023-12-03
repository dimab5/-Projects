using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;

public interface ICpu : IComponentValidator, IComputerCpuBuilderDirector
{
    int СoreFrequency { get; }
    int CoreCount { get; }
    Socket CpuSocket { get; }
    bool EmbeddedCore { get; }
    IReadOnlyList<int> SupportedMemoryFrequencies { get; }
    int HeatDissipation { get; }
    int PowerConsumption { get; }
}