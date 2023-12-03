using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;

public interface IBios : IBiosBuilderDirector
{
    string Type { get; }
    int Version { get; }
    IReadOnlyList<ICpu?> SupportedCpu { get; }
}