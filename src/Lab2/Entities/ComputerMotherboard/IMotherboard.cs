using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard;

public interface IMotherboard : IComponentValidator, IMotherboardBulderDirector
{
    Socket MotherboardSocket { get; }
    int PciCount { get; }
    int SataCount { get; }
    Chipset MotherboardChipset { get; }
    int SupportedDdr { get; }
    int NumberRam { get; }
    FormFactor MotherboardFormFactor { get; }
    IBios Bios { get; }
    IWifi? Wife { get; }
}