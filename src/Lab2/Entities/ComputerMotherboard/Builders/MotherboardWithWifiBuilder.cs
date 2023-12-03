using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Builders;

public class MotherboardWithWifiBuilder : MotherboardBuilderBase
{
    private readonly IWifi _wifiExtension;

    public MotherboardWithWifiBuilder(IWifi wifi)
    {
        _wifiExtension = wifi;
    }

    public override IMotherboard Create(
        Socket motherboardSocket,
        int pciCount,
        int sataCount,
        Chipset motherboardChipset,
        int supportedDdr,
        int numberRam,
        FormFactor motherboardFormFactor,
        IBios bios)
    {
        return new Motherboard(
            motherboardSocket,
            pciCount,
            sataCount,
            motherboardChipset,
            supportedDdr,
            numberRam,
            motherboardFormFactor,
            bios,
            _wifiExtension);
    }
}