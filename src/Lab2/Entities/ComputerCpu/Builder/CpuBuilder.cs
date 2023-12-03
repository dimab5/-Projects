using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu.Builder;

public class CpuBuilder : ICpuBuilder
{
    private int _coreFrequency;
    private int _coreCount;
    private Socket? _cpuSocket;
    private bool _embeddedCore;
    private IReadOnlyList<int>? _memoryFrequencies;
    private int _heatDissipation;
    private int _powerConsumption;

    public ICpuBuilder WithCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithCoreCount(int coreCount)
    {
        _coreCount = coreCount;
        return this;
    }

    public ICpuBuilder WithCpuSocket(Socket? cpuSocket)
    {
        _cpuSocket = cpuSocket;
        return this;
    }

    public ICpuBuilder WithEmbeddedCore(bool existEmbeddedCore)
    {
        _embeddedCore = existEmbeddedCore;
        return this;
    }

    public ICpuBuilder WithMemoryFrequencies(IReadOnlyList<int>? supportedMemoryFrequencies)
    {
        _memoryFrequencies = supportedMemoryFrequencies;
        return this;
    }

    public ICpuBuilder WithHeatDissipation(int heatDissipation)
    {
        _heatDissipation = heatDissipation;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ICpu Build()
    {
        return new Cpu(
            _coreFrequency,
            _coreCount,
            _cpuSocket ?? throw new InvalidOperationException(),
            _embeddedCore,
            _memoryFrequencies ?? throw new InvalidOperationException(),
            _heatDissipation,
            _powerConsumption);
    }
}