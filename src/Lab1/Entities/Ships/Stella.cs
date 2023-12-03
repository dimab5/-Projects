using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors.ClassDeflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.СorpusStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Stella : IShip
{
    public Stella()
    {
        ImpulseEngine = new CEngine();
        JumpEngine = new OmegaEngine();
        Deflector = new DeflectorClass1();
        CorpusStrength = new FirstClassCorpus();
    }

    public IImpulseEngine? ImpulseEngine { get; }
    public IJumpEngine? JumpEngine { get; }
    public IClassDeflector? Deflector { get; set; }
    public ICorpusStrength? CorpusStrength { get; }
}