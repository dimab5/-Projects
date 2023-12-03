namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

public class ActivePlasma : IFuel
{
    public ActivePlasma(int fuel)
    {
        Fuel = fuel;
        Cost = 10;
    }

    public int Cost { get; }
    public int Fuel { get; private set; }

    public void SumFuel(int countFuel)
    {
        Fuel += countFuel;
    }
}