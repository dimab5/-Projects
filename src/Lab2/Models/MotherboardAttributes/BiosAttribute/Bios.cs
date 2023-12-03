using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;

public class Bios : IBios
{
    public Bios(
        string type,
        int version,
        IReadOnlyList<ICpu?> supportedCpu)
    {
        Type = type;
        Version = version;
        SupportedCpu = supportedCpu;
    }

    public string Type { get; }
    public int Version { get; }
    public IReadOnlyList<ICpu?> SupportedCpu { get; }

    public IBiosBuilder Direct(IBiosBuilder biosBuilder)
    {
        biosBuilder
            .WithType(Type)
            .WithVersion(Version)
            .WithSupportedCpu(SupportedCpu);

        return biosBuilder;
    }
}