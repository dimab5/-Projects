using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock;

public interface IPowerBlock : IComponentValidator, IPowerBlockBuilderDirector
{
    int PeakLoad { get; }
}