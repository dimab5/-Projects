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

public class SystemBlockClass : ISystemBlock
{
    public SystemBlockClass(
        IMotherboard? motherboard,
        ICpu? cpu,
        IRam? ram,
        IWifi? wifi,
        ICoolingSystem? cooler,
        ICorpus? corpus,
        IPowerBlock? powerBlock,
        IVideoCard? videoCard,
        ISsd? ssd,
        IHdd? hhd)
    {
        Motherboard = motherboard;
        Cpu = cpu;
        Ram = ram;
        Wifi = wifi;
        Cooler = cooler;
        Corpus = corpus;
        PowerBlock = powerBlock;
        VideoCard = videoCard;
        Ssd = ssd;
        Hhd = hhd;
    }

    public IMotherboard? Motherboard { get; }
    public ICpu? Cpu { get; }
    public IRam? Ram { get; }
    public IWifi? Wifi { get; }
    public ICoolingSystem? Cooler { get; }
    public ICorpus? Corpus { get; }
    public IPowerBlock? PowerBlock { get; }
    public IVideoCard? VideoCard { get; }
    public ISsd? Ssd { get; }
    public IHdd? Hhd { get; }

    public PossibleResults? Validate(ISystemBlock systemBlock)
    {
        string result = string.Empty;

        if (Cpu == null)
        {
            result += "Processor not found.\n";
        }

        if (Motherboard == null)
        {
            result += "Motherboard not found.\n";
        }

        if (Ram == null)
        {
            result += "Ram not found.\n";
        }

        if (Cooler == null)
        {
            result += "Cooler not found.\n";
        }

        if (PowerBlock == null)
        {
            result += "PowerBlock not found.\n";
        }

        if (Cpu != null && !Cpu.EmbeddedCore && VideoCard == null)
        {
            result += "Not found videocard.\n";
        }

        if (Hhd == null && Ssd == null)
        {
            result += "No storage device found.\n";
        }

        if (Wifi != null && Motherboard?.Wife != null)
        {
            result += "WiFi network equipment conflict.\n";
        }

        if (string.IsNullOrEmpty(result))
        {
            return new PossibleResults.Success();
        }

        return new PossibleResults.Fail(result);
    }

    public ISystemBlockBuilder Direct(ISystemBlockBuilder systemBlockBuilder)
    {
        systemBlockBuilder
            .WithMotherboard(Motherboard)
            .WithCpu(Cpu)
            .WithRam(Ram)
            .WithCooler(Cooler)
            .WithCorpus(Corpus)
            .WithPowerBlock(PowerBlock)
            .WithVideoCard(VideoCard)
            .WithHdd(Hhd)
            .WithSsd(Ssd)
            .WithWifi(Wifi);

        return systemBlockBuilder;
    }
}