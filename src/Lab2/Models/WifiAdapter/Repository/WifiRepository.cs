using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter.Repository;

public class WifiRepository : IRepository<IWifi>
{
    private static Dictionary<string, IWifi> _wifiRepository = new Dictionary<string, IWifi>();

    public WifiRepository()
    {
        var wifiDirector = new StandartWifiBuilderDirector();

        _wifiRepository["StandartWifi"] =
            wifiDirector.Direct(new WifiBuilder()).Build();
    }

    public void AddComponent(string name, IWifi component)
    {
        _wifiRepository[name] = component;
    }

    public IWifi GetComponent(string name)
    {
        return _wifiRepository[name];
    }
}