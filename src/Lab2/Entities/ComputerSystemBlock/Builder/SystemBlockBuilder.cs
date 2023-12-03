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

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystemBlock.Builder;

public class SystemBlockBuilder : ISystemBlockBuilder
{
    private IMotherboard? _motherboard;
    private ICpu? _cpu;
    private IRam? _ram;
    private IWifi? _wifi;
    private ICoolingSystem? _cooler;
    private ICorpus? _corpus;
    private IPowerBlock? _powerBlock;
    private IVideoCard? _videoCard;
    private ISsd? _ssd;
    private IHdd? _hhd;

    public PossibleResults? BuildResult { get; private set; }

    // public SystemBlockBuilder()
    // {
    //     _motherboard = null;
    //     _cpu = null;
    //     _ram = null;
    //     _wifi = null;
    // }
    public ISystemBlockBuilder WithMotherboard(IMotherboard? motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ISystemBlockBuilder WithCpu(ICpu? cpu)
    {
        _cpu = cpu;
        return this;
    }

    public ISystemBlockBuilder WithRam(IRam? ram)
    {
        _ram = ram;
        return this;
    }

    public ISystemBlockBuilder WithWifi(IWifi? wifi)
    {
        _wifi = wifi;
        return this;
    }

    public ISystemBlockBuilder WithCooler(ICoolingSystem? cooler)
    {
        _cooler = cooler;
        return this;
    }

    public ISystemBlockBuilder WithCorpus(ICorpus? corpus)
    {
        _corpus = corpus;
        return this;
    }

    public ISystemBlockBuilder WithPowerBlock(IPowerBlock? powerBlock)
    {
        _powerBlock = powerBlock;
        return this;
    }

    public ISystemBlockBuilder WithVideoCard(IVideoCard? videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public ISystemBlockBuilder WithSsd(ISsd? ssd)
    {
        _ssd = ssd;
        return this;
    }

    public ISystemBlockBuilder WithHdd(IHdd? hhd)
    {
        _hhd = hhd;
        return this;
    }

    public ISystemBlock Build()
    {
        var computer = new SystemBlockClass(
            _motherboard,
            _cpu,
            _ram,
            _wifi,
            _cooler,
            _corpus,
            _powerBlock,
            _videoCard,
            _ssd,
            _hhd);

        var validator = new ComputerValidationResult(computer);
        BuildResult = validator.Validation();

        return computer;
    }
}