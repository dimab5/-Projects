using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;

public interface IVideoCard : IVideoCardBuilderDirector
{
    FormFactor VideoCardFormFactor { get; }
    int VideoMemory { get; }
    int PciVersion { get; }
    int ChipFrequency { get; }
    int PowerConsumption { get; }
}