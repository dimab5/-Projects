using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.SsdStore.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.SsdStore.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SsdStore.Repository;

public class SsdRepository : IRepository<ISsd>
{
    private static Dictionary<string, ISsd> _ssdRepository = new Dictionary<string, ISsd>();

    public SsdRepository()
    {
        var ssdDirector = new StandartSsdBuilderDirector();

        _ssdRepository["StandartSsd"] =
            ssdDirector.Direct(new SsdBuilder()).Build();
    }

    public void AddComponent(string name, ISsd component)
    {
        _ssdRepository[name] = component;
    }

    public ISsd GetComponent(string name)
    {
        return _ssdRepository[name];
    }
}