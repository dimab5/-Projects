using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp;

public interface IXmpProfileBuilder
{
    IXmpProfileBuilder WithTimings(IReadOnlyList<int> timings);
    IXmpProfileBuilder WithVoltage(int voltage);
    IXmpProfileBuilder WithFrequency(int frequency);
    IXmpProfile Build();
}