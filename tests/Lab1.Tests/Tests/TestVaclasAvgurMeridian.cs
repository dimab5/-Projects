using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles.CosmoWhales;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageRoute;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassageSpace;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class TestVaclasAvgurMeridian
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new Vaclas(), new Avgur(), new Meridian(),
                new NebulaeNitrideParticles(10000, new CosmoWhale(4)),
                new PossibleResults.Fail(),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void Route_VaclasAvgurMeridian_ShouldReturnFailSuccessSuccessInNebulaeNitrideParticles(
        IShip firstShip, IShip secondShip, IShip thirdShip, ISpace space, PossibleResults firstExpectedValue)
    {
        var firstShipTest = new ResultWriter(firstShip, space);
        var secondShipTest = new Route(secondShip, space);
        var thirdShipTest = new Route(thirdShip, space);

        PossibleResults firstResult = firstShipTest.WriteResult();
        ResultPassingSpace secondResult = secondShipTest.PassingRoute();
        ResultPassingSpace thirdResult = thirdShipTest.PassingRoute();

        Assert.Equal(firstResult, firstExpectedValue);
        Assert.True(secondShipTest.Ship.Deflector?.HealthLevel.IsDead());
        Assert.False(secondResult.Time != 0 && secondResult.Fuels.Sum(fuel => fuel.Fuel) != 0);
        Assert.False(thirdResult.Time != 0 && secondResult.Fuels.Sum(fuel => fuel.Fuel) != 0);
        Assert.False(!thirdShipTest.Ship.Deflector?.HealthLevel.IsDead());
    }
}