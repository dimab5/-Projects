using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Factories;

public class MotherboardWithoutWifiBuilderFactory : IMotherboardBuildFactory
{
    public IMotherboardBuilder Create()
    {
        return new MotherboardWithoutWifiBuilder();
    }
}