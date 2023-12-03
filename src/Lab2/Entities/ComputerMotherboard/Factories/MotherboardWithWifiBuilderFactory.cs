using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Factories;

public class MotherboardWithWifiBuilderFactory : IMotherboardBuildFactory
{
    private readonly IWifi _wifiExtension;

    public MotherboardWithWifiBuilderFactory(IWifi wifi)
    {
        _wifiExtension = wifi;
    }

    public IMotherboardBuilder Create()
    {
        return new MotherboardWithWifiBuilder(_wifiExtension);
    }
}