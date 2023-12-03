using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler;

public interface ICoolingSystem : ICoolingSystemBuilderDirector
{
    Dimensions CoolingSystemDimensions { get; }
    IReadOnlyList<Socket> SupportedSockets { get; }
    int Tdp { get; }
}