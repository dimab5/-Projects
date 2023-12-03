using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PassageRoute;

public class ElectorBestShip : IElectorBestShip
{
    public ElectorBestShip()
    {
    }

    public IShip? ChooseOptimalShip(params ResultPassingSpace[] results)
    {
        IShip? bestShip = null;
        int minFuel = 0;
        ResultPassingSpace[] resultsArray = results.ToArray();

        int i = 0;
        for (; i < resultsArray.Length; i++)
        {
            if (resultsArray[i].Fuels.Sum(fuel => fuel.Fuel) > 0 && resultsArray[i].Time > 0)
            {
                minFuel = resultsArray[i].Fuels.Sum(fuel => fuel.Fuel);
                bestShip = resultsArray[i].Ship;
                break;
            }
        }

        for (; i < resultsArray.Length; i++)
        {
            if (resultsArray[i].Fuels.Sum(fuel => fuel.Fuel) > 0
                && resultsArray[i].Time > 0
                && minFuel > resultsArray[i].Fuels.Sum(fuel => fuel.Fuel))
            {
                minFuel = resultsArray[i].Fuels.Sum(fuel => fuel.Fuel);
                bestShip = resultsArray[i].Ship;
            }
        }

        return bestShip;
    }
}