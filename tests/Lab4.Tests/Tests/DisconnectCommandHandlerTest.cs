using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Tests;

public class DisconnectCommandHandlerTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new CommandValue("disconnect"),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void DisconnectCommandHandler_ReturnDisconnectCommand(CommandValue inputCommand)
    {
        var commandParser = new CommandParser();

        ICommand? resultCommand = commandParser.Handle(inputCommand);

        Assert.True(resultCommand is DisconnectionCommand);
    }
}