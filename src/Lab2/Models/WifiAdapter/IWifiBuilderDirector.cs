namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;

public interface IWifiBuilderDirector
{
    IWifiBuilder Direct(IWifiBuilder wifiBuilder);
}