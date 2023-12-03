using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard.Builder;

public class VideoCardBuilder : IVideoCardBuilder
{
    private FormFactor? _videoCardFormFactor;
    private int _videoMemory;
    private int _pciVersion;
    private int _chipFrequency;
    private int _powerConsumption;

    public IVideoCardBuilder WithVideoCardFormFactor(FormFactor videoCardFormFactor)
    {
        _videoCardFormFactor = videoCardFormFactor;
        return this;
    }

    public IVideoCardBuilder WithVideoMemory(int videoMemory)
    {
        _videoMemory = videoMemory;
        return this;
    }

    public IVideoCardBuilder WithPciVersion(int pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IVideoCardBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IVideoCard Build()
    {
        return new VideoCardClass(
            _videoCardFormFactor ?? throw new InvalidOperationException(),
            _videoMemory,
            _pciVersion,
            _chipFrequency,
            _powerConsumption);
    }
}