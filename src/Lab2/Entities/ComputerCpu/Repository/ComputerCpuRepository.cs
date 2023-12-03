using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu.Repository;

public class ComputerCpuRepository : IRepository<ICpu>
{
    private static Dictionary<string, ICpu> _cpuRepository = new Dictionary<string, ICpu>();

    static ComputerCpuRepository()
    {
        var cpuDirector = new IntelCore7BuilderDirector();
        _cpuRepository["amdRyzen7Cpu"] = cpuDirector.Direct(new CpuBuilder()).Build();
    }

    public void AddComponent(string name, ICpu component)
    {
        _cpuRepository[name] = component;
    }

    public ICpu GetComponent(string name)
    {
        return _cpuRepository[name];
    }
}