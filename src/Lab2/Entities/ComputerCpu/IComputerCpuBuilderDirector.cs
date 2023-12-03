namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;

public interface IComputerCpuBuilderDirector
{
    ICpuBuilder Direct(ICpuBuilder cpuBuilder);
}
