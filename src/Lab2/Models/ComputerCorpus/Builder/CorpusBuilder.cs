using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus.Builder;

public class CorpusBuilder : ICorpusBuilder
{
    private FormFactor? _maxFormFactor;
    private IReadOnlyList<FormFactor>? _supportedFormFactors;
    private Dimensions? _corpusDimensions;

    public ICorpusBuilder WithMaxFormFactor(FormFactor maxFormFactor)
    {
        _maxFormFactor = maxFormFactor;
        return this;
    }

    public ICorpusBuilder WithSupportedFormFactors(IReadOnlyList<FormFactor> supportedFormFactors)
    {
        _supportedFormFactors = supportedFormFactors;
        return this;
    }

    public ICorpusBuilder WithCorpusDimensions(Dimensions corpusDimensions)
    {
        _corpusDimensions = corpusDimensions;
        return this;
    }

    public ICorpus Build()
    {
        return new Corpus(
            _maxFormFactor ?? throw new InvalidOperationException(),
            _supportedFormFactors ?? throw new InvalidOperationException(),
            _corpusDimensions ?? throw new InvalidOperationException());
    }
}