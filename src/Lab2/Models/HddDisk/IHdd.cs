namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk;

public interface IHdd : IHddBuilderDirector
{
    int Container { get; }
    int SpindleRotationSpeed { get; }
    int PowerConsumption { get; }
}