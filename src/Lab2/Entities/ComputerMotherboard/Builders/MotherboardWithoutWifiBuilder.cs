using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Builders;

public class MotherboardWithoutWifiBuilder : MotherboardBuilderBase
{
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
            null);
    }
}