using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines.JumpEngines;

public interface IJumpEngine
{
    int FuelConsumption(int distance);
    TimeFuelResult? PassingResult(int distance);
}