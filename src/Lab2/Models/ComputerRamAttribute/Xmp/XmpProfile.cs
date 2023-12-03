using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp;

public class XmpProfile : IXmpProfile
{
    public XmpProfile(
        IReadOnlyList<int> timings,
        int voltage,
        int frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public IReadOnlyList<int> Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }

    public IXmpProfileBuilder Direct(IXmpProfileBuilder xmpProfileBuilder)
    {
        xmpProfileBuilder
            .WithFrequency(Frequency)
            .WithTimings(Timings)
            .WithVoltage(Voltage);

        return xmpProfileBuilder;
    }
}