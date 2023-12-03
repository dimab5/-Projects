using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock.Repository;

public class PowerBlockRepository : IRepository<IPowerBlock>
{
    private static Dictionary<string, IPowerBlock> _powerBlockRepository = new Dictionary<string, IPowerBlock>();

    public PowerBlockRepository()
    {
        var powerBlockDirector = new StandartPowerBlockBuilderDirector();

        _powerBlockRepository["StandartPowerBlock"] =
            powerBlockDirector.Direct(new PowerBlockBuilder()).Build();
    }

    public void AddComponent(string name, IPowerBlock component)
    {
        _powerBlockRepository[name] = component;
    }

    public IPowerBlock GetComponent(string name)
    {
        return _powerBlockRepository[name];
    }
}