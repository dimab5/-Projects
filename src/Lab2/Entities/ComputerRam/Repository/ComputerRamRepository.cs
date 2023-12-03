using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerRam.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerRam.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerRam.Repository;

public class ComputerRamRepository : IRepository<IRam>
{
    private static Dictionary<string, IRam> _ramRepository = new Dictionary<string, IRam>();

    static ComputerRamRepository()
    {
        var ramDirector = new Hpe256GbRamBuilderDirector();

        _ramRepository["hpe256Gb"] = ramDirector.Direct(new RamBuilder()).Build();
    }

    public void AddComponent(string name, IRam component)
    {
        _ramRepository[name] = component;
    }

    public IRam GetComponent(string name)
    {
        return _ramRepository[name];
    }
}