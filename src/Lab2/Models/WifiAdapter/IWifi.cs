namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;

public interface IWifi : IWifiBuilderDirector
{
    int WiFiStandardVersion { get; }
    bool BluetoothModule { get; }
    int PciVersion { get; }
    int PowerConsumption { get; }
}