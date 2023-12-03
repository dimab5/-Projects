using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus;

public class Corpus : ICorpus
{
    public Corpus(
        FormFactor maxFormFactor,
        IReadOnlyList<FormFactor> supportedFormFactors,
        Dimensions corpusDimensions)
    {
        MaxFormFactor = maxFormFactor;
        SupportedFormFactors = supportedFormFactors;
        CorpusDimensions = corpusDimensions;
    }

    public FormFactor MaxFormFactor { get; }
    public IReadOnlyList<FormFactor> SupportedFormFactors { get; }
    public Dimensions CorpusDimensions { get; }

    public PossibleResults? Validate(ISystemBlock systemBlock)
    {
        string result = string.Empty;

        if (MaxFormFactor.Length <= systemBlock.VideoCard?.VideoCardFormFactor.Length &&
            MaxFormFactor.Width <= systemBlock.VideoCard?.VideoCardFormFactor.Width)
        {
            result = "The video card is too big and does not fit into the case.\n";
        }

        if (!SupportedFormFactors.Any(
                formFactor =>
                    formFactor.Length > systemBlock.Motherboard?.MotherboardFormFactor.Length
                    && formFactor.Width > systemBlock.Motherboard?.MotherboardFormFactor.Width))
        {
            result += "The motherboard is too big and does not fit into the case.\n";
        }

        if (CorpusDimensions.Length < systemBlock.Cooler?.CoolingSystemDimensions.Length &&
            CorpusDimensions.Width < systemBlock.Cooler.CoolingSystemDimensions.Width &&
            CorpusDimensions.Height < systemBlock.Cooler.CoolingSystemDimensions.Height)
        {
            result += "The cooling system is too large and does not fit into the case.\n";
        }

        if (string.IsNullOrEmpty(result))
        {
            return new PossibleResults.Success();
        }

        return new PossibleResults.Fail(result);
    }

    public ICorpusBuilder Direct(ICorpusBuilder corpusBuilder)
    {
        corpusBuilder
            .WithMaxFormFactor(MaxFormFactor)
            .WithCorpusDimensions(CorpusDimensions)
            .WithSupportedFormFactors(SupportedFormFactors);

        return corpusBuilder;
    }
}