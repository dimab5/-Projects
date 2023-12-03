using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors.ClassDeflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.СorpusStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Avgur : IShip
{
    public Avgur()
    {
        ImpulseEngine = new EEngine();
        JumpEngine = new AlphaEngine();
        Deflector = new DeflectorClass3();
        CorpusStrength = new ThirdClassCorpus();
    }

    public IImpulseEngine? ImpulseEngine { get; }
    public IJumpEngine? JumpEngine { get; }
    public IClassDeflector? Deflector { get; set; }
    public ICorpusStrength? CorpusStrength { get; }
}