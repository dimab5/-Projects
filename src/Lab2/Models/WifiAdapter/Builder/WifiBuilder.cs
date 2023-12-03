namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter.Builder;

public class WifiBuilder : IWifiBuilder
{
    private int _wiFiStandardVersion;
    private bool _bluetoothModule;
    private int _pciVersion;
    private int _powerConsumption;

    public IWifiBuilder WithWiFiStandardVersion(int wiFiStandardVersion)
    {
        _wiFiStandardVersion = wiFiStandardVersion;
        return this;
    }

    public IWifiBuilder WithBluetoothModule(bool bluetoothModule)
    {
        _bluetoothModule = bluetoothModule;
        return this;
    }

    public IWifiBuilder WithPciVersion(int pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public IWifiBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IWifi Build()
    {
        return new Wifi(
            _wiFiStandardVersion,
            _bluetoothModule,
            _pciVersion,
            _powerConsumption);
    }
}