using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.SupportedJedecVoltage;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerRam.Builder;

public class RamBuilder : IRamBuilder
{
    private int _availableMemory;
    private JedecVoltage? _supportedJedecVoltage;
    private IXmpProfile? _xmp;
    private FormFactor? _formFact;
    private int _versionDdr;
    private int _powerConsumption;

    public IRamBuilder WithAvailableMemory(int availableMemory)
    {
        _availableMemory = availableMemory;
        return this;
    }

    public IRamBuilder WithSupportedJedecVoltage(JedecVoltage jedecVoltage)
    {
        _supportedJedecVoltage = jedecVoltage;
        return this;
    }

    public IRamBuilder WithXmp(IXmpProfile xmpProfile)
    {
        _xmp = xmpProfile;
        return this;
    }

    public IRamBuilder WithFormFact(FormFactor formFactor)
    {
        _formFact = formFactor;
        return this;
    }

    public IRamBuilder WithVersionDdr(int versionDdr)
    {
        _versionDdr = versionDdr;
        return this;
    }

    public IRamBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRam Build()
    {
        return new Ram(
            _availableMemory,
            _supportedJedecVoltage ?? throw new InvalidOperationException(),
            _xmp ?? throw new InvalidOperationException(),
            _formFact ?? throw new InvalidOperationException(),
            _versionDdr,
            _powerConsumption);
    }
}