using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.Connections;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Tests;

public class ConnectCommandHandlerTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new CommandValue("connect C:\\prog\\test -m local"),
                new CommandValue("C:\\prog\\test"),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void ConnectCommandHandler_ReturnConnectCommand(
        CommandValue inputCommand, CommandValue pathExpected)
    {
        var commandParser = new CommandParser();

        ICommand? resultCommand = commandParser.Handle(inputCommand);

        var connectCommand = resultCommand as ConnectCommand;
        var localConnectionStrategy = connectCommand?.ConectionStrategy as LocalConnectionStrategy;

        Assert.Equal(localConnectionStrategy?.AbsolutePath, pathExpected);
        Assert.True(connectCommand?.ConectionStrategy is LocalConnectionStrategy);
    }
}