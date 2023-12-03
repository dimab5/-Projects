namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;

public interface IWifiBuilder
{
    IWifiBuilder WithWiFiStandardVersion(int wiFiStandardVersion);
    IWifiBuilder WithBluetoothModule(bool bluetoothModule);
    IWifiBuilder WithPciVersion(int pciVersion);
    IWifiBuilder WithPowerConsumption(int powerConsumption);
    IWifi Build();
}