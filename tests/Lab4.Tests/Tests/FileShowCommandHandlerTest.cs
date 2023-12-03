using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Tests;

public class FileShowCommandHandlerTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new CommandValue("file show FileFirsDirectory.txt -m console"),
                new CommandValue("FileFirsDirectory.txt"),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void FileShowCommandHandler_ReturnFileShowCommand(
        CommandValue inputCommand, CommandValue pathExpected)
    {
        var commandParser = new CommandParser();

        ICommand? resultCommand = commandParser.Handle(inputCommand);

        var fileShowCommand = resultCommand as FileShowCommand;

        Assert.Equal(fileShowCommand?.Path, pathExpected);
    }
}