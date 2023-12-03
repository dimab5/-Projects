namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

public class GravitationalMatter : IFuel
{
    public GravitationalMatter(int fuel)
    {
        Fuel = fuel;
        Cost = 50;
    }

    public int Cost { get; }
    public int Fuel { get; private set; }

    public void SumFuel(int countFuel)
    {
        Fuel += countFuel;
    }
}