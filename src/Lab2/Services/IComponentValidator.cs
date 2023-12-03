using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IComponentValidator
{
    PossibleResults? Validate(ISystemBlock systemBlock);
}