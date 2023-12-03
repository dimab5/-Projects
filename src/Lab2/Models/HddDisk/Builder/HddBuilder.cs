namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk.Builder;

public class HddBuilder : IHddBuilder
{
    private int _container;
    private int _spindleRotationSpeed;
    private int _powerConsumption;

    public IHddBuilder WithContainer(int container)
    {
        _container = container;
        return this;
    }

    public IHddBuilder WithSpindleRotationSpeed(int spindleRotationSpeed)
    {
        _spindleRotationSpeed = spindleRotationSpeed;
        return this;
    }

    public IHddBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IHdd Build()
    {
        return new Hdd(
            _container,
            _spindleRotationSpeed,
            _powerConsumption);
    }
}