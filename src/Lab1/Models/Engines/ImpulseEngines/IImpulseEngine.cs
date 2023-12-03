using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.ImpulseEngines;

public interface IImpulseEngine
{
    int FuelConsumption(int distance);
    TimeFuelResult? PassingResult(int distance);
}