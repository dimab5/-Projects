using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;

public interface IBiosBuilder
{
    IBiosBuilder WithType(string type);
    IBiosBuilder WithVersion(int versin);
    IBiosBuilder WithSupportedCpu(IReadOnlyList<ICpu?> supportedCpu);
    IBios Build();
}