using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp;

public interface IXmpProfile : IXmpBuilderDirector
{
    IReadOnlyList<int> Timings { get; }
    int Voltage { get; }
    int Frequency { get; }
}