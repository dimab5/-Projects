using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp.Builder;

public class XmpProfileBuilder : IXmpProfileBuilder
{
    private IReadOnlyList<int>? _timings;
    private int _voltage;
    private int _frequency;

    public IXmpProfileBuilder WithTimings(IReadOnlyList<int> timings)
    {
        _timings = timings;
        return this;
    }

    public IXmpProfileBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXmpProfileBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IXmpProfile Build()
    {
        return new XmpProfile(
            _timings ?? throw new InvalidOperationException(),
            _voltage,
            _frequency);
    }
}