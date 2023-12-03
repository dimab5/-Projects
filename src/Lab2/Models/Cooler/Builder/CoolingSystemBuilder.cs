using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler.Builder;

public class CoolingSystemBuilder : ICoolingSystemBuilder
{
    private Dimensions? _coolingSystemDimensions;
    private IReadOnlyList<Socket>? _supportedSockets;
    private int _tdp;

    public ICoolingSystemBuilder WithDimensions(Dimensions dimensions)
    {
        _coolingSystemDimensions = dimensions;
        return this;
    }

    public ICoolingSystemBuilder WithSupportedSockets(IReadOnlyList<Socket> sockets)
    {
        _supportedSockets = sockets;
        return this;
    }

    public ICoolingSystemBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICoolingSystem Build()
    {
        return new CoolingSystem(
            _coolingSystemDimensions ?? throw new InvalidOperationException(),
            _supportedSockets ?? throw new InvalidOperationException(),
            _tdp);
    }
}