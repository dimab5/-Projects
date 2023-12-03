using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors.PhotonicDeflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles.AntimatterFlares;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaces;

public class NebulaeIncreasedDensitySpace : ISpace
{
    private int _length;
    private IObstaclesCollect _obstaclesCollection;

    public NebulaeIncreasedDensitySpace(int length, IAntimatterFlare obstacle)
    {
        _length = length;
        _obstaclesCollection = new ObstacleCollect(new List<IObstacle> { obstacle });
    }

    public TimeFuelResult? ShipResult(IShip ship)
    {
        decimal time = 0;
        IFuel fuel = new GravitationalMatter(0);
        IObstacle obstacle = _obstaclesCollection.Obstacles[0];

        if (ship.JumpEngine is null ||
            (ship.Deflector is not IPhotonicDefector && obstacle.Count > 0))
        {
            return new TimeFuelResult(time, new List<IFuel> { new ActivePlasma(0), fuel });
        }

        if (ship.Deflector is IPhotonicDefector photonicDeflector)
        {
            photonicDeflector.GetAntimatterFlare(obstacle.DealDamage * obstacle.Count);

            if (photonicDeflector.HealthLevel.IsDead())
            {
                return new TimeFuelResult(time, new List<IFuel> { new ActivePlasma(0), fuel });
            }
        }

        return ship.JumpEngine.PassingResult(_length);
    }
}