namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock.Builder;

public class PowerBlockBuilder : IPowerBlockBuilder
{
    private int _peakLoad;

    public IPowerBlockBuilder WithPeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public IPowerBlock Build()
    {
        return new PowerBlockClass(
            _peakLoad);
    }
}