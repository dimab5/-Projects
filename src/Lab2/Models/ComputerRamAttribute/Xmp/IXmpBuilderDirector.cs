namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp;

public interface IXmpBuilderDirector
{
    IXmpProfileBuilder Direct(IXmpProfileBuilder xmpProfileBuilder);
}