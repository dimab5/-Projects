using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Directors;

public class StandartMotherboardBuilderDirector : IMotherboardBulderDirector
{
    public IMotherboardBuilder Direct(IMotherboardBuilder motherboardBuilder)
    {
        var computerCpuRepository = new ComputerCpuRepository();

        motherboardBuilder
            .WithSocket(new Socket("LGA 1200"))
            .WithPciCount(16)
            .WithSataCount(3)
            .WithChipset(new Chipset(new List<int> { 2933, 2666, 2400, 2133 }, true))
            .WithSupportedDdr(4)
            .WithNumberRam(64)
            .WithFormFactor(new FormFactor(1, 2))
            .WithBios(
                new Bios("Bios", 3, new List<ICpu> { computerCpuRepository.GetComponent("amdRyzen7Cpu") }));

        return motherboardBuilder;
    }
}