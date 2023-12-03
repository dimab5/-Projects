using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute.Directors;

public class StandartBiosBuilderDirector : IBiosBuilderDirector
{
    public IBiosBuilder Direct(IBiosBuilder biosBuilder)
    {
        var computerCpuRepository = new ComputerCpuRepository();

        biosBuilder
            .WithType("Bios")
            .WithVersion(3)
            .WithSupportedCpu(new List<ICpu> { computerCpuRepository.GetComponent("amdRyzen7Cpu") });

        return biosBuilder;
    }
}