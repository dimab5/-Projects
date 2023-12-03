namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk;

public class Hdd : IHdd
{
    public Hdd(
        int container,
        int spindleRotationSpeed,
        int powerConsumption)
    {
        Container = container;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Container { get; }
    public int SpindleRotationSpeed { get; }
    public int PowerConsumption { get; }

    public IHddBuilder Direct(IHddBuilder hddBuilder)
    {
        hddBuilder
            .WithContainer(Container)
            .WithPowerConsumption(PowerConsumption)
            .WithSpindleRotationSpeed(SpindleRotationSpeed);

        return hddBuilder;
    }
}