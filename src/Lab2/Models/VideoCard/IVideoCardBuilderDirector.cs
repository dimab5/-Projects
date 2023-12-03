namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;

public interface IVideoCardBuilderDirector
{
    IVideoCardBuilder Direct(IVideoCardBuilder videoCardBuilder);
}