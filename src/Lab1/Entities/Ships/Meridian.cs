using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors.ClassDeflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Emitter;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.СorpusStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meridian : IShip, IEmmiterDecorator
{
    public Meridian()
    {
        ImpulseEngine = new EEngine();
        JumpEngine = null;
        Deflector = new DeflectorClass2();
        CorpusStrength = new SecondClassCorpus();
    }

    public IImpulseEngine? ImpulseEngine { get; }
    public IJumpEngine? JumpEngine { get; }
    public IClassDeflector? Deflector { get; set; }
    public ICorpusStrength? CorpusStrength { get; }
}