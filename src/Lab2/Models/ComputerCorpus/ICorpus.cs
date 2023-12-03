using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus;

public interface ICorpus : IComponentValidator, IComputerCorpusBuilderDirector
{
    FormFactor MaxFormFactor { get; }
    IReadOnlyList<FormFactor> SupportedFormFactors { get; }
    Dimensions CorpusDimensions { get; }
}