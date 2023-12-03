namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard;

public interface IMotherboardBulderDirector
{
    IMotherboardBuilder Direct(IMotherboardBuilder motherboardBuilder);
}