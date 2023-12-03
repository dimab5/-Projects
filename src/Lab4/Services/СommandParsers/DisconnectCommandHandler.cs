using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandSeparators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class DisconnectCommandHandler : CommandHandlerBase
{
    public override ICommand? Handle(CommandValue commandValue)
    {
        string[] commands = new CommandSeparator(commandValue).Separate();

        if (commands[0] == "disconnect")
        {
                return new DisconnectionCommand();
        }

        return NextCommand?.Handle(commandValue);
    }
}