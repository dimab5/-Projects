using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithSocket(Socket socket);
    IMotherboardBuilder WithPciCount(int pciCount);
    IMotherboardBuilder WithSataCount(int sataCount);
    IMotherboardBuilder WithChipset(Chipset chipset);
    IMotherboardBuilder WithSupportedDdr(int supportedDdr);
    IMotherboardBuilder WithNumberRam(int numberRam);
    IMotherboardBuilder WithFormFactor(FormFactor formFactor);
    IMotherboardBuilder WithBios(IBios bios);
    IMotherboardBuilder WithWifi(IWifi? wifi);
    IMotherboard Build();
}