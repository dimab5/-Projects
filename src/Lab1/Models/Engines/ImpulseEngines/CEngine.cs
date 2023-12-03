using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.ImpulseEngines;

public class CEngine : IImpulseEngine
{
    private const int CEngineFuelConsumption = 100;
    private const int CSpeed = 50;
    private const int StartEngine = 50;

    public CEngine()
    {
    }

    public int FuelConsumption(int distance)
    {
        return (distance * CEngineFuelConsumption) + StartEngine;
    }

    public TimeFuelResult? PassingResult(int distance)
    {
        return new TimeFuelResult(
            distance / CSpeed,
            new List<IFuel>
            {
                new ActivePlasma(CEngineFuelConsumption),
                new GravitationalMatter(0),
            });
    }
}