using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Tests;

public class FileDeleteCommandHandlerTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new CommandValue("file delete FileFirsDirectory.txt"),
                new CommandValue("FileFirsDirectory.txt"),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void FileDeleteCommandHandler_ReturnDeleteCopyCommand(
        CommandValue inputCommand, CommandValue pathExpected)
    {
        var commandParser = new CommandParser();

        ICommand? resultCommand = commandParser.Handle(inputCommand);

        var fileDeleteCommand = resultCommand as FileDeleteCommand;

        Assert.Equal(fileDeleteCommand?.Path, pathExpected);
    }
}