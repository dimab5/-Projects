namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock.Directors;

public class StandartPowerBlockBuilderDirector : IPowerBlockBuilderDirector
{
    public IPowerBlockBuilder Direct(IPowerBlockBuilder powerBlockBuilder)
    {
        powerBlockBuilder
            .WithPeakLoad(1000);

        return powerBlockBuilder;
    }
}