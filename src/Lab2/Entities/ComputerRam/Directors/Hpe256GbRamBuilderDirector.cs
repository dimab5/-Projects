using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.SupportedJedecVoltage;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerRam.Directors;

public class Hpe256GbRamBuilderDirector : IComputerRamBuilderDitector
{
    public IRamBuilder Direct(IRamBuilder ramBuilder)
    {
        ramBuilder
            .WithAvailableMemory(256)
            .WithSupportedJedecVoltage(new JedecVoltage(1000, 2000))
            .WithXmp(new XmpProfile(new List<int> { 10, 20, 30 }, 2000, 2666))
            .WithFormFact(new FormFactor(1, 2))
            .WithVersionDdr(4)
            .WithPowerConsumption(3000);

        return ramBuilder;
    }
}