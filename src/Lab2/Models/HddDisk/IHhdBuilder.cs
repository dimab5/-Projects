namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk;

public interface IHhdBuilder
{
    IHhdBuilder WithContainer(int container);
    IHhdBuilder WithSpindleRotationSpeed(int spindleRotationSpeed);
    IHhdBuilder WithPowerConsumption(int powerConsumption);
    IHhd Build();
}