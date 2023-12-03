using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerValidationResult
{
    private readonly ISystemBlock _systemBlock;

    public ComputerValidationResult(ISystemBlock systemBlock)
    {
        _systemBlock = systemBlock;
    }

    public PossibleResults Validation()
    {
        var resultsList = new Collection<PossibleResults?>();

        new ComputerValidator().Validate(_systemBlock, resultsList);

        return new ResultCreator(resultsList).CreateResult();
    }
}