using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidations;

public interface IComponentValidator
{
    IComponentValidator AddNext(IComponentValidator componentValidator);
    void Handle(ISystemBlock systemBlock, Collection<PossibleResults?> possibleResultsList);
}