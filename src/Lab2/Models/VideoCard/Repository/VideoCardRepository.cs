using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard.Repository;

public class VideoCardRepository : IRepository<IVideoCard>
{
    private static Dictionary<string, IVideoCard> _videoCardRepository = new Dictionary<string, IVideoCard>();

    public VideoCardRepository()
    {
        var ssdDirector = new StandartVideoCardBuilderDirector();

        _videoCardRepository["StandartVideoCard"] =
            ssdDirector.Direct(new VideoCardBuilder()).Build();
    }

    public void AddComponent(string name, IVideoCard component)
    {
        _videoCardRepository[name] = component;
    }

    public IVideoCard GetComponent(string name)
    {
        return _videoCardRepository[name];
    }
}