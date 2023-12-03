using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Tests;

public class TreeListCommandHandlerTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new CommandValue("tree list -d 2"), 2,
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void TreeListCommandHandler_ReturnTreeListCommand(
        CommandValue inputCommand, int depthExpected)
    {
        var commandParser = new CommandParser();

        ICommand? resultCommand = commandParser.Handle(inputCommand);

        var treeListCommand = resultCommand as TreeListCommand;

        Assert.Equal(treeListCommand?.Depth, depthExpected);
    }
}