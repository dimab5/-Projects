using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidations;

public class ComputerValidator
{
    private IComponentValidator _componentValidator;

    public ComputerValidator()
    {
        _componentValidator = new SystemBlockValidator();

        _componentValidator
            .AddNext(new CorpusValidator())
            .AddNext(new CpuValidator())
            .AddNext(new MotherboardValidator())
            .AddNext(new RamValidator())
            .AddNext(new PowerBlockValidator());
    }

    public void Validate(ISystemBlock systemBlock, Collection<PossibleResults?> resultsList)
    {
        _componentValidator.Handle(systemBlock, resultsList);
    }
}