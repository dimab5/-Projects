namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;

public class Wifi : IWifi
{
    public Wifi(
        int wiFiStandardVersion,
        bool bluetoothModule,
        int pciVersion,
        int powerConsumption)
    {
        WiFiStandardVersion = wiFiStandardVersion;
        BluetoothModule = bluetoothModule;
        PciVersion = pciVersion;
        PowerConsumption = powerConsumption;
    }

    public int WiFiStandardVersion { get; }
    public bool BluetoothModule { get; }
    public int PciVersion { get; }
    public int PowerConsumption { get; }

    public IWifiBuilder Direct(IWifiBuilder wifiBuilder)
    {
        throw new System.NotImplementedException();
    }
}