using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.JumpEngines;

public class OmegaEngine : IJumpEngine
{
    private const int _speed = 100;
    private const int _rangeTravel = 1000;

    public OmegaEngine()
    {
    }

    public int FuelConsumption(int distance)
    {
        return distance * (int)Math.Log2(distance);
    }

    public TimeFuelResult? PassingResult(int distance)
    {
        if (distance > _rangeTravel)
        {
            return new TimeFuelResult(
                0,
                new List<IFuel>
                {
                    new ActivePlasma(0),
                    new GravitationalMatter(FuelConsumption(0)),
                });
        }

        return new TimeFuelResult(
            distance / _speed,
            new List<IFuel>
            {
                new ActivePlasma(0),
                new GravitationalMatter(FuelConsumption(distance)),
            });
    }
}