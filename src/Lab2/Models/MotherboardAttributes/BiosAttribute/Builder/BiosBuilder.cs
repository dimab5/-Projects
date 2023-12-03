using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute.Builder;

public class BiosBuilder : IBiosBuilder
{
    private string? _type;
    private int _version;
    private IReadOnlyList<ICpu?>? _supportedCpu;

    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(int versin)
    {
        _version = versin;
        return this;
    }

    public IBiosBuilder WithSupportedCpu(IReadOnlyList<ICpu?> supportedCpu)
    {
        _supportedCpu = supportedCpu;
        return this;
    }

    public IBios Build()
    {
        return new Bios(
            _type ?? throw new InvalidOperationException(),
            _version,
            _supportedCpu ?? throw new InvalidOperationException());
    }
}