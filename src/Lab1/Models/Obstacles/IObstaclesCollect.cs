using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public interface IObstaclesCollect
{
    IReadOnlyList<IObstacle> Obstacles { get; }
    public void GetDamage(IShip ship);
}