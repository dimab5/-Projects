using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Tests;

public class FileRenameCommandHandlerTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new CommandValue("file rename FileFirstDirectory.txt FileSecondDirectory.txt"),
                new CommandValue("FileFirstDirectory.txt"),
                new CommandValue("FileSecondDirectory.txt"),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void FileRenameCommandHandler_ReturnRenameCopyCommand(
        CommandValue inputCommand, CommandValue pathExpected, CommandValue nameExpected)
    {
        var commandParser = new CommandParser();

        ICommand? resultCommand = commandParser.Handle(inputCommand);

        var fileRenameCommand = resultCommand as FileRenameCommand;

        Assert.Equal(fileRenameCommand?.Path, pathExpected);
        Assert.Equal(fileRenameCommand?.Name, nameExpected);
    }
}