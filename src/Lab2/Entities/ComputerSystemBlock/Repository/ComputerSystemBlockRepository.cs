using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Repository;

public class ComputerSystemBlockRepository : IRepository<ISystemBlock>
{
    private static Dictionary<string, ISystemBlock> _systemBlockRepository = new Dictionary<string, ISystemBlock>();

    static ComputerSystemBlockRepository()
    {
        IComputerSystemBlockBuilderDirector systemBlockDirector = new GamingSystemBlockBuilderDirector();
        _systemBlockRepository["gamingSystemBlock"] =
            systemBlockDirector.Direct(new SystemBlockBuilder()).Build();

        systemBlockDirector = new StandartSystemBlockBuilderDirector();
        _systemBlockRepository["standartSystemBlock"] =
            systemBlockDirector.Direct(new SystemBlockBuilder()).Build();
    }

    public void AddComponent(string name, ISystemBlock component)
    {
        _systemBlockRepository[name] = component;
    }

    public ISystemBlock GetComponent(string name)
    {
        return _systemBlockRepository[name];
    }
}