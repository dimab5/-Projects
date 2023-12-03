using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles.StoneObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaces;

public class OrdinarySpace : ISpace
{
    private IObstaclesCollect _obstaclesCollection;
    private int _length;

    public OrdinarySpace(int length, params IStoneObstacle[] obstacles)
    {
        _length = length;
        var obstaclesTmp = new List<IObstacle>();

        foreach (IStoneObstacle obstacle in obstacles)
        {
            obstaclesTmp.Add(obstacle);
        }

        _obstaclesCollection = new ObstacleCollect(obstaclesTmp);
    }

    public TimeFuelResult? ShipResult(IShip ship)
    {
        decimal time = 0;
        IFuel fuel = new ActivePlasma(0);

        _obstaclesCollection.GetDamage(ship);

        if (ship.CorpusStrength?.HealthLevel.IsDead() == null)
        {
            return new TimeFuelResult(time, new List<IFuel> { fuel, new GravitationalMatter(0) });
        }

        return ship.ImpulseEngine?.PassingResult(_length);
    }
}