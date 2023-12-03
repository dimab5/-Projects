using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandSeparators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class FileDeleteCommandHandler : CommandHandlerBase
{
    public override ICommand? Handle(CommandValue commandValue)
    {
        string[] commands = new CommandSeparator(commandValue).Separate();

        if (commands[0] == "file" && commands[1] == "delete")
        {
            string path = commands[2];

            return new FileDeleteCommand(new CommandValue(path));
        }

        return NextCommand?.Handle(commandValue);
    }
}