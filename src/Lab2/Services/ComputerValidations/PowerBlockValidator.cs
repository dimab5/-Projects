using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidations;

public class PowerBlockValidator : ComputerValidatorBase
{
    public override void Handle(ISystemBlock systemBlock, Collection<PossibleResults?> possibleResultsList)
    {
        possibleResultsList.Add(systemBlock.PowerBlock?.Validate(systemBlock));
        NextComponentValidator?.Handle(systemBlock, possibleResultsList);
    }
}