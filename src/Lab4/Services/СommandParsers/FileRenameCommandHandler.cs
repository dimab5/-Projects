using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandSeparators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class FileRenameCommandHandler : CommandHandlerBase
{
    public override ICommand? Handle(CommandValue commandValue)
    {
        string[] commands = new CommandSeparator(commandValue).Separate();

        if (commands[0] == "file" && commands[1] == "rename")
        {
            string path = commands[2];
            string name = commands[3];

            return new FileRenameCommand(
                new CommandValue(path),
                new CommandValue(name));
        }

        return NextCommand?.Handle(commandValue);
    }
}