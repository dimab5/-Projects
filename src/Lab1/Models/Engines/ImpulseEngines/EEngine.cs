using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.ImpulseEngines;

public class EEngine : IImpulseEngine
{
    private const int EEngineFuelConsumption = 200;
    private const int StartEngine = 100;

    public EEngine()
    {
    }

    public int FuelConsumption(int distance)
    {
        return (distance * EEngineFuelConsumption) + StartEngine;
    }

    public TimeFuelResult? PassingResult(int distance)
    {
        return new TimeFuelResult(
            distance / (int)Math.Exp(distance),
            new List<IFuel>
            {
                new ActivePlasma(EEngineFuelConsumption),
                new GravitationalMatter(0),
            });
    }
}