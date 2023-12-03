using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;

public class VideoCardClass : IVideoCard
{
    public VideoCardClass(
        FormFactor videoCardFormFactor,
        int videoMemory,
        int pciVersion,
        int chipFrequency,
        int powerConsumption)
    {
        VideoCardFormFactor = videoCardFormFactor;
        VideoMemory = videoMemory;
        PciVersion = pciVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public FormFactor VideoCardFormFactor { get; }
    public int VideoMemory { get; }
    public int PciVersion { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }

    public IVideoCardBuilder Direct(IVideoCardBuilder videoCardBuilder)
    {
        videoCardBuilder
            .WithVideoCardFormFactor(VideoCardFormFactor)
            .WithChipFrequency(ChipFrequency)
            .WithPowerConsumption(PowerConsumption)
            .WithPciVersion(PciVersion)
            .WithVideoMemory(VideoMemory);

        return videoCardBuilder;
    }
}