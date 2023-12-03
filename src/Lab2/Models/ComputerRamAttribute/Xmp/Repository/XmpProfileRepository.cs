using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.Xmp.Repository;

public class XmpProfileRepository : IRepository<IXmpProfile>
{
    private static Dictionary<string, IXmpProfile> _xmpRepository = new Dictionary<string, IXmpProfile>();

    static XmpProfileRepository()
    {
        var xmpDirector = new StandartXmpBuilderDirector();

        _xmpRepository["standartXmp"] =
            xmpDirector.Direct(new XmpProfileBuilder()).Build();
    }

    public void AddComponent(string name, IXmpProfile component)
    {
        _xmpRepository[name] = component;
    }

    public IXmpProfile GetComponent(string name)
    {
        return _xmpRepository[name];
    }
}