namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler;

public interface ICoolingSystemBuilderDirector
{
    ICoolingSystemBuilder Direct(ICoolingSystemBuilder coolingSystemBuilder);
}