using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

public record TimeFuelResult(decimal Time, IReadOnlyList<IFuel> Fuels);