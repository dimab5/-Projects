namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter.Directors;

public class StandartWifiBuilderDirector : IWifiBuilderDirector
{
    public IWifiBuilder Direct(IWifiBuilder wifiBuilder)
    {
        wifiBuilder
            .WithPciVersion(3)
            .WithPowerConsumption(10)
            .WithBluetoothModule(true)
            .WithWiFiStandardVersion(1);

        return wifiBuilder;
    }
}