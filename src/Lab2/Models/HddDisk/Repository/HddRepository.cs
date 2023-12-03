using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk.Repository;

public class HddRepository : IRepository<IHdd>
{
    private static Dictionary<string, IHdd> _hddReposytory = new Dictionary<string, IHdd>();

    public HddRepository()
    {
        var hddDirector = new StandartHddBuilderDirector();

        _hddReposytory["StandartHdd"] =
            hddDirector.Direct(new HddBuilder()).Build();
    }

    public void AddComponent(string name, IHdd component)
    {
        _hddReposytory[name] = component;
    }

    public IHdd GetComponent(string name)
    {
        return _hddReposytory[name];
    }
}