namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus;

public interface IComputerCorpusBuilderDirector
{
    ICorpusBuilder Direct(ICorpusBuilder corpusBuilder);
}