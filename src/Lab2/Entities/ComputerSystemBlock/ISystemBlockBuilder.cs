using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerRam;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCorpus;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Models.HddDisk;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PowerBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Models.SsdStore;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock;

public interface ISystemBlockBuilder
{
    PossibleResults? BuildResult { get; }
    ISystemBlockBuilder WithMotherboard(IMotherboard? motherboard);
    ISystemBlockBuilder WithCpu(ICpu? cpu);
    ISystemBlockBuilder WithRam(IRam? ram);
    ISystemBlockBuilder WithWifi(IWifi? wifi);
    ISystemBlockBuilder WithCooler(ICoolingSystem? cooler);
    ISystemBlockBuilder WithCorpus(ICorpus? corpus);
    ISystemBlockBuilder WithPowerBlock(IPowerBlock? powerBlock);
    ISystemBlockBuilder WithVideoCard(IVideoCard? videoCard);
    ISystemBlockBuilder WithSsd(ISsd? ssd);
    ISystemBlockBuilder WithHdd(IHdd? hhd);
    ISystemBlock Build();
}