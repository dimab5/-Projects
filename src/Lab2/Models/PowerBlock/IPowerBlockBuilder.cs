namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock;

public interface IPowerBlockBuilder
{
    IPowerBlockBuilder WithPeakLoad(int peakLoad);
    IPowerBlock Build();
}