using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Tests;

public class FileCopyCommandHandlerTest
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new CommandValue("file copy FileFirsDirectory.txt SecondDirectory"),
                new CommandValue("FileFirsDirectory.txt"),
                new CommandValue("SecondDirectory"),
            },
        };

    [Theory]
    [MemberData(nameof(Data))]
    public void FileCopyCommandHandler_ReturnFileCopyCommand(
        CommandValue inputCommand,
        CommandValue sourcePathExpected,
        CommandValue destinationPathExpected)
    {
            var commandParser = new CommandParser();

            ICommand? resultCommand = commandParser.Handle(inputCommand);

            var fileCopyCommand = resultCommand as FileCopyCommand;

            Assert.Equal(fileCopyCommand?.SourcePath, sourcePathExpected);
            Assert.Equal(fileCopyCommand?.DestinationPath, destinationPathExpected);
        }
}