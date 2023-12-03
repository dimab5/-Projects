namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk;

public interface IHddBuilderDirector
{
    IHddBuilder Direct(IHddBuilder hddBuilder);
}