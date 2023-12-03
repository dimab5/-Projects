namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

public interface IFuel
{
    int Cost { get; }
    int Fuel { get; }
    void SumFuel(int countFuel);
}