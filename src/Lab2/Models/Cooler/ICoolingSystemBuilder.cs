using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler;

public interface ICoolingSystemBuilder
{
    ICoolingSystemBuilder WithDimensions(Dimensions dimensions);
    ICoolingSystemBuilder WithSupportedSockets(IReadOnlyList<Socket> sockets);
    ICoolingSystemBuilder WithTdp(int tdp);
    ICoolingSystem Build();
}