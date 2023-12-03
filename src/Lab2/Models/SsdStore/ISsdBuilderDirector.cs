namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SsdStore;

public interface ISsdBuilderDirector
{
    ISsdBuilder Direct(ISsdBuilder ssdBuilder);
}