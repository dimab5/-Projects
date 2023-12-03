using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler;

public class CoolingSystem : ICoolingSystem
{
    public CoolingSystem(
        Dimensions coolingSystemDimensions,
        IReadOnlyList<Socket> supportedSockets,
        int tdp)
    {
        CoolingSystemDimensions = coolingSystemDimensions;
        SupportedSockets = supportedSockets;
        Tdp = tdp;
    }

    public Dimensions CoolingSystemDimensions { get; }
    public IReadOnlyList<Socket> SupportedSockets { get; }
    public int Tdp { get; }

    public ICoolingSystemBuilder Direct(ICoolingSystemBuilder coolingSystemBuilder)
    {
        coolingSystemBuilder
            .WithDimensions(CoolingSystemDimensions)
            .WithSupportedSockets(SupportedSockets)
            .WithTdp(Tdp);

        return coolingSystemBuilder;
    }
}