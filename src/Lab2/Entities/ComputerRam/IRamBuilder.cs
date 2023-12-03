using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.SupportedJedecVoltage;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerRam;

public interface IRamBuilder
{
    IRamBuilder WithAvailableMemory(int availableMemory);
    IRamBuilder WithSupportedJedecVoltage(JedecVoltage jedecVoltage);
    IRamBuilder WithXmp(IXmpProfile xmpProfile);
    IRamBuilder WithFormFact(FormFactor formFactor);
    IRamBuilder WithVersionDdr(int versionDdr);
    IRamBuilder WithPowerConsumption(int powerConsumption);
    IRam Build();
}