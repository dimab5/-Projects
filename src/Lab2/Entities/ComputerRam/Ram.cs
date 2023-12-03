using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.SupportedJedecVoltage;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerRam;

public class Ram : IRam
{
    public Ram(
        int availableMemory,
        JedecVoltage supportedJedecVoltage,
        IXmpProfile xmp,
        FormFactor formFact,
        int versionDdr,
        int powerConsumption)
    {
        AvailableMemory = availableMemory;
        SupportedJedecVoltage = supportedJedecVoltage;
        Xmp = xmp;
        FormFact = formFact;
        VersionDdr = versionDdr;
        PowerConsumption = powerConsumption;
    }

    public int AvailableMemory { get; }
    public JedecVoltage SupportedJedecVoltage { get; }
    public IXmpProfile Xmp { get; }
    public FormFactor FormFact { get; }
    public int VersionDdr { get; }
    public int PowerConsumption { get; }

    public PossibleResults? Validate(ISystemBlock systemBlock)
    {
        string result = string.Empty;

        if (systemBlock.Cpu != null && systemBlock.Cpu.SupportedMemoryFrequencies.All(
                frequency => Xmp.Frequency >= frequency))
        {
            result += "XMP profile incompatibility.\n";
        }

        if (string.IsNullOrEmpty(result))
        {
            return new PossibleResults.Success();
        }

        return new PossibleResults.SuccessWithComments(result);
    }

    public IRamBuilder Direct(IRamBuilder ramBuilder)
    {
        ramBuilder
            .WithAvailableMemory(AvailableMemory)
            .WithSupportedJedecVoltage(SupportedJedecVoltage)
            .WithXmp(Xmp)
            .WithFormFact(FormFact)
            .WithVersionDdr(VersionDdr)
            .WithPowerConsumption(PowerConsumption);

        return ramBuilder;
    }
}