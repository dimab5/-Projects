using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

public record ResultPassingSpace(decimal Time, IReadOnlyList<IFuel> Fuels, IShip Ship);