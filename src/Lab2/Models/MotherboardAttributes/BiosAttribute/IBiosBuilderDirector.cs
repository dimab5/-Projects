namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;

public interface IBiosBuilderDirector
{
    IBiosBuilder Direct(IBiosBuilder biosBuilder);
}