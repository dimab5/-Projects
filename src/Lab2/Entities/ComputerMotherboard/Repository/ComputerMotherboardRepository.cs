using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Repository;

public class ComputerMotherboardRepository : IRepository<IMotherboard>
{
    private static Dictionary<string, IMotherboard> _motherboardRepository = new Dictionary<string, IMotherboard>();

    static ComputerMotherboardRepository()
    {
        var motherboardFactory = new MotherboardWithWifiBuilderFactory(
            new Wifi(1, true, 3, 4));
        IMotherboardBuilder motherboardBuilder = motherboardFactory.Create();
        var motherboardDirector = new StandartMotherboardBuilderDirector();

        _motherboardRepository["gigabyteH410M"] =
            motherboardDirector.Direct(motherboardBuilder).Build();
    }

    public void AddComponent(string name, IMotherboard component)
    {
        _motherboardRepository[name] = component;
    }

    public IMotherboard GetComponent(string name)
    {
        return _motherboardRepository[name];
    }
}