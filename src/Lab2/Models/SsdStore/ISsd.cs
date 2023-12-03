namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SsdStore;

public interface ISsd : ISsdBuilderDirector
{
    string ConnectionOption { get; }
    int Container { get; }
    int MaximumOperatingSpeed { get; }
    int PowerConsumption { get; }
}