using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerRamAttribute.FormFactorAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.BiosAttribute;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerMotherboard.Builders;

public abstract class MotherboardBuilderBase : IMotherboardBuilder
{
    private Socket? _motherboardSocket;
    private int _pciCount;
    private int _sataCount;
    private Chipset? _motherboardChipset;
    private int _supportedDdr;
    private int _numberRam;
    private FormFactor? _motherboardFormFactor;
    private IBios? _bios;
    private IWifi? _wife;

    public IMotherboardBuilder WithSocket(Socket socket)
    {
        _motherboardSocket = socket;
        return this;
    }

    public IMotherboardBuilder WithPciCount(int pciCount)
    {
        _pciCount = pciCount;
        return this;
    }

    public IMotherboardBuilder WithSataCount(int sataCount)
    {
        _sataCount = sataCount;
        return this;
    }

    public IMotherboardBuilder WithChipset(Chipset chipset)
    {
        _motherboardChipset = chipset;
        return this;
    }

    public IMotherboardBuilder WithSupportedDdr(int supportedDdr)
    {
        _supportedDdr = supportedDdr;
        return this;
    }

    public IMotherboardBuilder WithNumberRam(int numberRam)
    {
        _numberRam = numberRam;
        return this;
    }

    public IMotherboardBuilder WithFormFactor(FormFactor formFactor)
    {
        _motherboardFormFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder WithBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboardBuilder WithWifi(IWifi? wifi)
    {
        _wife = wifi;
        return this;
    }

    public IMotherboard Build()
    {
        return Create(
            _motherboardSocket ?? throw new InvalidOperationException(),
            _pciCount,
            _sataCount,
            _motherboardChipset ?? throw new InvalidOperationException(),
            _supportedDdr,
            _numberRam,
            _motherboardFormFactor ?? throw new InvalidOperationException(),
            _bios ?? throw new InvalidOperationException());
    }

    public abstract IMotherboard Create(
        Socket motherboardSocket,
        int pciCount,
        int sataCount,
        Chipset motherboardChipset,
        int supportedDdr,
        int numberRam,
        FormFactor motherboardFormFactor,
        IBios bios);
}