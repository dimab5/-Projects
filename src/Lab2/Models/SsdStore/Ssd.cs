namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SsdStore;

public class Ssd : ISsd
{
    public Ssd(
        string connectionOption,
        int container,
        int maximumOperatingSpeed,
        int powerConsumption)
    {
        ConnectionOption = connectionOption;
        Container = container;
        MaximumOperatingSpeed = maximumOperatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public string ConnectionOption { get; }
    public int Container { get; }
    public int MaximumOperatingSpeed { get; }
    public int PowerConsumption { get; }

    public ISsdBuilder Direct(ISsdBuilder ssdBuilder)
    {
        ssdBuilder
            .WithConnectionOption(ConnectionOption)
            .WithContainer(Container)
            .WithPowerConsumption(PowerConsumption)
            .WithMaximumOperatingSpeed(MaximumOperatingSpeed);

        return ssdBuilder;
    }
}