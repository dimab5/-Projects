using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard;

public class Motherboard : IMotherboard
{
    public Motherboard(
        Socket motherboardSocket,
        int pciCount,
        int sataCount,
        Chipset motherboardChipset,
        int supportedDdr,
        int numberRam,
        FormFactor motherboardFormFactor,
        IBios bios,
        IWifi? wifi)
    {
        MotherboardSocket = motherboardSocket;
        PciCount = pciCount;
        SataCount = sataCount;
        MotherboardChipset = motherboardChipset;
        SupportedDdr = supportedDdr;
        NumberRam = numberRam;
        MotherboardFormFactor = motherboardFormFactor;
        Bios = bios;
        Wife = wifi;
    }

    public Socket MotherboardSocket { get; }
    public int PciCount { get; }
    public int SataCount { get; }
    public Chipset MotherboardChipset { get; }
    public int SupportedDdr { get; }
    public int NumberRam { get; }
    public FormFactor MotherboardFormFactor { get; }
    public IBios Bios { get; }
    public IWifi? Wife { get; }

    public PossibleResults? Validate(ISystemBlock systemBlock)
    {
        string result = string.Empty;

        if (systemBlock.Cpu?.CpuSocket != MotherboardSocket)
        {
            result += "The processor does not fit the motherboard due to differences in the socket.\n";
        }

        if (!Bios.SupportedCpu.Contains(systemBlock.Cpu))
        {
            result += "The bios does not support the processor.\n";
        }

        if (SupportedDdr != (systemBlock.Ram?.VersionDdr ?? 0))
        {
            result += "Unsupported DDR standard.\n";
        }

        if (MotherboardChipset.SupportedFrequencies.All(
                frequency => systemBlock.Ram?.Xmp.Frequency < frequency))
        {
            result += "Insufficient RAM frequency.\n";
        }

        if (string.IsNullOrEmpty(result))
        {
            return new PossibleResults.Success();
        }

        return new PossibleResults.SuccessWithComments(result);
    }

    public IMotherboardBuilder Direct(IMotherboardBuilder motherboardBuilder)
    {
        IMotherboardBuilder builder = motherboardBuilder
            .WithSocket(MotherboardSocket)
            .WithPciCount(PciCount)
            .WithSataCount(SataCount)
            .WithChipset(MotherboardChipset)
            .WithSupportedDdr(SupportedDdr)
            .WithNumberRam(NumberRam)
            .WithFormFactor(MotherboardFormFactor)
            .WithBios(Bios)
            .WithWifi(Wife);

        return builder;
    }
}