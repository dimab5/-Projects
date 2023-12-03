using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus;

public interface ICorpusBuilder
{
    ICorpusBuilder WithMaxFormFactor(FormFactor maxFormFactor);
    ICorpusBuilder WithSupportedFormFactors(IReadOnlyList<FormFactor> supportedFormFactors);
    ICorpusBuilder WithCorpusDimensions(Dimensions corpusDimensions);
    ICorpus Build();
}