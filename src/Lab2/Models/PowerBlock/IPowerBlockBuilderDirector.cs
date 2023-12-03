namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock;

public interface IPowerBlockBuilderDirector
{
    IPowerBlockBuilder Direct(IPowerBlockBuilder powerBlockBuilder);
}