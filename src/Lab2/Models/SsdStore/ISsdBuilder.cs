namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SsdStore;

public interface ISsdBuilder
{
    ISsdBuilder WithConnectionOption(string connectionOption);
    ISsdBuilder WithContainer(int container);
    ISsdBuilder WithMaximumOperatingSpeed(int maximumOperatingSpeed);
    ISsdBuilder WithPowerConsumption(int powerConsumption);
    ISsd Build();
}