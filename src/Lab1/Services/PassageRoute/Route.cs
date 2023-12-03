using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PassageRoute;

public class Route : IRoute
{
    public Route(IShip inputShip, params ISpace[] spaces)
    {
        Ship = inputShip;
        var spacesTemp = new List<ISpace>();

        foreach (ISpace space in spaces)
        {
            spacesTemp.Add(space);
        }

        RouteSpaces = spacesTemp;
    }

    public IShip Ship { get; }

    public IReadOnlyList<ISpace> RouteSpaces { get; } = new List<ISpace>();

    public ResultPassingSpace PassingRoute()
    {
        decimal time = 0;
        var fuels = new List<IFuel> { new ActivePlasma(0), new GravitationalMatter(0) };

        foreach (ISpace space in RouteSpaces)
        {
            var spacePassage = new SpaceFlight(Ship, space);
            TimeFuelResult? tempTimeFuelResult = space.ShipResult(Ship);
            if (tempTimeFuelResult != null)
            {
                var tempResult = new ResultPassingSpace(
                    tempTimeFuelResult.Time,
                    tempTimeFuelResult.Fuels,
                    Ship);

                if (tempResult.Time == 0 && tempResult.Fuels.All(fuel => fuel.Fuel == 0))
                {
                    return new ResultPassingSpace(
                        tempResult.Time,
                        tempResult.Fuels,
                        tempResult.Ship);
                }

                for (int i = 0; i < fuels.Count; i++)
                {
                    fuels[i].SumFuel(tempResult.Fuels[i].Fuel);
                }

                time += tempResult.Time;
            }
        }

        return new ResultPassingSpace(time, fuels, Ship);
    }
}