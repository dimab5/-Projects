using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus.Directors;

public class StandartCorpusBuilderDirector : IComputerCorpusBuilderDirector
{
    public ICorpusBuilder Direct(ICorpusBuilder corpusBuilder)
    {
        corpusBuilder
            .WithMaxFormFactor(new FormFactor(4, 5))
            .WithCorpusDimensions(new Dimensions(5, 6, 7))
            .WithSupportedFormFactors(new List<FormFactor> { new FormFactor(4, 5) });

        return corpusBuilder;
    }
}