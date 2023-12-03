using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidations;

public abstract class ComputerValidatorBase : IComponentValidator
{
    protected IComponentValidator? NextComponentValidator { get; private set; }

    public IComponentValidator AddNext(IComponentValidator componentValidator)
    {
        NextComponentValidator = componentValidator;
        return componentValidator;
    }

    public abstract void Handle(ISystemBlock systemBlock, Collection<PossibleResults?> possibleResultsList);
}