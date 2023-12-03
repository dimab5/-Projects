using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerRam.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpusAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Directors;

public class GamingSystemBlockBuilderDirector : IComputerSystemBlockBuilderDirector
{
    public ISystemBlockBuilder Direct(ISystemBlockBuilder systemBlockBuilder)
    {
        var computerMotherboardRepository = new ComputerMotherboardRepository();
        var computerCpuRepository = new ComputerCpuRepository();
        var computerRamRepository = new ComputerRamRepository();

        systemBlockBuilder
            .WithMotherboard(computerMotherboardRepository.GetComponent("gigabyteH410M"))
            .WithCpu(computerCpuRepository.GetComponent("amdRyzen7Cpu"))
            .WithRam(computerRamRepository.GetComponent("hpe256Gb"))
            .WithCooler(new CoolingSystem(
                new Dimensions(3, 4, 5),
                new List<Socket> { new Socket("AM4") },
                5))
            .WithCorpus(
                new Corpus(
                    new FormFactor(6, 7),
                    new List<FormFactor> { new FormFactor(6, 7) },
                    new Dimensions(7, 8, 9)))
            .WithPowerBlock(new PowerBlockClass(1000))
            .WithVideoCard(new VideoCardClass(new FormFactor(1, 2), 4, 5, 6, 7))
            .WithHdd(new Hdd(10, 15, 20));

        return systemBlockBuilder;
    }
}