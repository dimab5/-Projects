using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandSeparators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class FileCopyCommandHandler : CommandHandlerBase
{
    public override ICommand? Handle(CommandValue commandValue)
    {
        string[] commands = new CommandSeparator(commandValue).Separate();

        if (commands[0] == "file" && commands[1] == "copy")
        {
            string sourcePath = commands[2];
            string destinationPath = commands[3];

            return new FileCopyCommand(
                new CommandValue(sourcePath),
                new CommandValue(destinationPath));
        }

        return NextCommand?.Handle(commandValue);
    }
}