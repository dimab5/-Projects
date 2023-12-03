using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler.Repository;

public class CoolingSystemRepository : IRepository<ICoolingSystem>
{
    private static Dictionary<string, ICoolingSystem> _coolingSystemRepository = new Dictionary<string, ICoolingSystem>();

    public CoolingSystemRepository()
    {
        var coolingSystemDirector = new StandartCoolingSystemBuilderDirector();

        _coolingSystemRepository["standartCoolingSystem"] =
            coolingSystemDirector.Direct(new CoolingSystemBuilder()).Build();
    }

    public void AddComponent(string name, ICoolingSystem component)
    {
        _coolingSystemRepository[name] = component;
    }

    public ICoolingSystem GetComponent(string name)
    {
        return _coolingSystemRepository[name];
    }
}