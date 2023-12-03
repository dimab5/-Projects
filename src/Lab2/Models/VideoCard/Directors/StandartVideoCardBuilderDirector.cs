using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard.Directors;

public class StandartVideoCardBuilderDirector : IVideoCardBuilderDirector
{
    public IVideoCardBuilder Direct(IVideoCardBuilder videoCardBuilder)
    {
        videoCardBuilder
            .WithVideoCardFormFactor(new FormFactor(5, 10))
            .WithChipFrequency(60)
            .WithPowerConsumption(100)
            .WithPciVersion(2)
            .WithVideoMemory(256);

        return videoCardBuilder;
    }
}