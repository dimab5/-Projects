namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk;

public interface IHddBuilder
{
    IHddBuilder WithContainer(int container);
    IHddBuilder WithSpindleRotationSpeed(int spindleRotationSpeed);
    IHddBuilder WithPowerConsumption(int powerConsumption);
    IHdd Build();
}