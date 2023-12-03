using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus.Repository;

public class ComputerCorpusRepository : IRepository<ICorpus>
{
    private static Dictionary<string, ICorpus> _computerCorpusRepository = new Dictionary<string, ICorpus>();

    static ComputerCorpusRepository()
    {
        var corpusDirector = new StandartCorpusBuilderDirector();

        _computerCorpusRepository["standartCorpus"] =
            corpusDirector.Direct(new CorpusBuilder()).Build();
    }

    public void AddComponent(string name, ICorpus component)
    {
        _computerCorpusRepository[name] = component;
    }

    public ICorpus GetComponent(string name)
    {
        return _computerCorpusRepository[name];
    }
}