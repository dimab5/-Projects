using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Tests;

public class TreeGotoCommandHandlerTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new CommandValue("tree goto FirstDirectory"),
                new CommandValue("FirstDirectory"),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void TreeGotoCommandHandler_ReturnTreeGotoCommand(
        CommandValue inputCommand, CommandValue pathExpected)
    {
        var commandParser = new CommandParser();

        ICommand? resultCommand = commandParser.Handle(inputCommand);

        var treeGotoCommand = resultCommand as TreeGotoCommand;

        Assert.Equal(treeGotoCommand?.Path, pathExpected);
    }
}