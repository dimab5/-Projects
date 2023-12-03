using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandSeparators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class TreeGotoCommandHandler : CommandHandlerBase
{
    public override ICommand? Handle(CommandValue commandValue)
    {
        string[] commands = new CommandSeparator(commandValue).Separate();

        if (commands[0] == "tree" && commands[1] == "goto")
        {
            string path = commands[2];

            return new TreeGotoCommand(new CommandValue(path));
        }

        return NextCommand?.Handle(commandValue);
    }
}