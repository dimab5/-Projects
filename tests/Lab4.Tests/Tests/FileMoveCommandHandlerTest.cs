using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Tests;

public class FileMoveCommandHandlerTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new CommandValue("file move FileFirsDirectory.txt SecondDirectory"),
                new CommandValue("FileFirsDirectory.txt"),
                new CommandValue("SecondDirectory"),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void FileMoveCommandHandler_ReturnMoveCopyCommand(
        CommandValue inputCommand, CommandValue pathExpected, CommandValue modeExpected)
    {
        var commandParser = new CommandParser();

        ICommand? resultCommand = commandParser.Handle(inputCommand);

        var fileMoveCommand = resultCommand as FileMoveCommand;

        Assert.Equal(fileMoveCommand?.SourcePath, pathExpected);
        Assert.Equal(fileMoveCommand?.DestinationPath, modeExpected);
    }
}