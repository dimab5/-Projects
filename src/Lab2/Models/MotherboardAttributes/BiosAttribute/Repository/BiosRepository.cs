using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute.Repository;

public class BiosRepository : IRepository<IBios>
{
    private static Dictionary<string, IBios> _biosRepository = new Dictionary<string, IBios>();

    public BiosRepository()
    {
        var biosDirector = new StandartBiosBuilderDirector();

        _biosRepository["StandartBios"] =
            biosDirector.Direct(new BiosBuilder()).Build();
    }

    public void AddComponent(string name, IBios component)
    {
        _biosRepository[name] = component;
    }

    public IBios GetComponent(string name)
    {
        return _biosRepository[name];
    }
}