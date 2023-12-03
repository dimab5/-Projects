using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class ObstacleCollect : IObstaclesCollect
{
    public ObstacleCollect(IReadOnlyList<IObstacle> obstacles)
    {
        Obstacles = obstacles;
    }

    public IReadOnlyList<IObstacle> Obstacles { get; }

    public void GetDamage(IShip ship)
    {
        foreach (IObstacle obstacle in Obstacles)
        {
            for (int i = 0; i < obstacle.Count; i++)
            {
                if (ship?.Deflector?.HealthLevel.IsDead() is false)
                {
                    ship.Deflector.GetDamage(obstacle.DealDamage);
                }
                else if (ship?.CorpusStrength != null && !ship.CorpusStrength.HealthLevel.IsDead())
                {
                    ship.CorpusStrength.GetDamage(obstacle.DealDamage);
                }
            }
        }
    }
}