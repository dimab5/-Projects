using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Emitter;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles.CosmoWhales;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaces;

public class NebulaeNitrideParticles : ISpace
{
    private int _length;
    private IObstaclesCollect _obstaclesCollection;

    public NebulaeNitrideParticles(int length, CosmoWhale obstacle)
    {
        _length = length;
        _obstaclesCollection = new ObstacleCollect(new List<IObstacle> { obstacle });
    }

    public TimeFuelResult? ShipResult(IShip ship)
    {
        decimal time = 0;
        IFuel fuel = new ActivePlasma(0);

        if (ship.ImpulseEngine is not EEngine)
        {
            return new TimeFuelResult(time, new List<IFuel> { fuel, new GravitationalMatter(0) });
        }

        _obstaclesCollection.GetDamage(ship);

        if (ship.CorpusStrength != null && ship.CorpusStrength.HealthLevel.IsDead() && ship is not IEmmiterDecorator)
        {
            return new TimeFuelResult(time, new List<IFuel> { fuel, new GravitationalMatter(0) });
        }

        return ship.ImpulseEngine.PassingResult(_length);
    }
}