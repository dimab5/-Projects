namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;

public interface IComputerSystemBlockBuilderDirector
{
    ISystemBlockBuilder Direct(ISystemBlockBuilder systemBlockBuilder);
}