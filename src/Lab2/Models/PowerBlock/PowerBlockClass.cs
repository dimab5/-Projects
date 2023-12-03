using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock;

public class PowerBlockClass : IPowerBlock
{
    public PowerBlockClass(
        int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; }

    public PossibleResults? Validate(ISystemBlock systemBlock)
    {
        string result = string.Empty;

        if (PeakLoad < (systemBlock.Cpu?.PowerConsumption ?? 0)
            + (systemBlock.Ram?.PowerConsumption ?? 0)
            + (systemBlock.VideoCard?.PowerConsumption ?? 0)
            + (systemBlock.Hhd?.PowerConsumption ?? 0)
            + (systemBlock.Ssd?.PowerConsumption ?? 0)
            + (systemBlock.Wifi?.PowerConsumption ?? 0))
        {
            result += "Insufficient power of the power supply.\n";
        }

        if (string.IsNullOrEmpty(result))
        {
            return new PossibleResults.Success();
        }

        return new PossibleResults.SuccessWithComments(result);
    }

    public IPowerBlockBuilder Direct(IPowerBlockBuilder powerBlockBuilder)
    {
        powerBlockBuilder
            .WithPeakLoad(PeakLoad);

        return powerBlockBuilder;
    }
}