using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;

public interface IVideoCardBuilder
{
    IVideoCardBuilder WithVideoCardFormFactor(FormFactor videoCardFormFactor);
    IVideoCardBuilder WithVideoMemory(int videoMemory);
    IVideoCardBuilder WithPciVersion(int pciVersion);
    IVideoCardBuilder WithChipFrequency(int chipFrequency);
    IVideoCardBuilder WithPowerConsumption(int powerConsumption);
    IVideoCard Build();
}