using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SsdStore.Builder;

public class SsdBuilder : ISsdBuilder
{
    private string? _connectionOption;
    private int _container;
    private int _maximumOperatingSpeed;
    private int _powerConsumption;

    public ISsdBuilder WithConnectionOption(string connectionOption)
    {
        _connectionOption = connectionOption;
        return this;
    }

    public ISsdBuilder WithContainer(int container)
    {
        _container = container;
        return this;
    }

    public ISsdBuilder WithMaximumOperatingSpeed(int maximumOperatingSpeed)
    {
        _maximumOperatingSpeed = maximumOperatingSpeed;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ISsd Build()
    {
        return new Ssd(
            _connectionOption ?? throw new InvalidOperationException(),
            _container,
            _maximumOperatingSpeed,
            _powerConsumption);
    }
}