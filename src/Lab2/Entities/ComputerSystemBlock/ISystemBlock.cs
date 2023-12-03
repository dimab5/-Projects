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

public interface ISystemBlock : IComponentValidator, IComputerSystemBlockBuilderDirector
{
    IMotherboard? Motherboard { get; }
    ICpu? Cpu { get; }
    IRam? Ram { get; }
    IWifi? Wifi { get; }
    ICoolingSystem? Cooler { get; }
    ICorpus? Corpus { get; }
    IPowerBlock? PowerBlock { get; }
    IVideoCard? VideoCard { get; }
    ISsd? Ssd { get; }
    IHdd? Hhd { get; }
}