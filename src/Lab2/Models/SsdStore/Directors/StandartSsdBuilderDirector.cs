namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SsdStore.Directors;

public class StandartSsdBuilderDirector : ISsdBuilderDirector
{
    public ISsdBuilder Direct(ISsdBuilder ssdBuilder)
    {
        ssdBuilder
            .WithConnectionOption("connect")
            .WithContainer(12)
            .WithPowerConsumption(10)
            .WithMaximumOperatingSpeed(5);

        return ssdBuilder;
    }
}