using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.SupportedJedecVoltage;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerRam;

public interface IRam : IComponentValidator, IComputerRamBuilderDitector
{
    int AvailableMemory { get; }
    JedecVoltage SupportedJedecVoltage { get; }
    IXmpProfile Xmp { get; }
    FormFactor FormFact { get; }
    int VersionDdr { get; }
    int PowerConsumption { get; }
}