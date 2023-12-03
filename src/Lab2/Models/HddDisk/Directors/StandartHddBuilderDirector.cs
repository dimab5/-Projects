namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk.Directors;

public class StandartHddBuilderDirector : IHddBuilderDirector
{
    public IHddBuilder Direct(IHddBuilder hddBuilder)
    {
        hddBuilder
            .WithContainer(4)
            .WithPowerConsumption(23)
            .WithSpindleRotationSpeed(50);

        return hddBuilder;
    }
}