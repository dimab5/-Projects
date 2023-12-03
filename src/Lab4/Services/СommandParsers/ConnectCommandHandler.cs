using Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.Connections;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandSeparators;
using Itmo.ObjectOrientedProgramming.Lab4.Services.PathHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class ConnectCommandHandler : CommandHandlerBase
{
    public override ICommand? Handle(CommandValue commandValue)
    {
        string[] commands = new CommandSeparator(commandValue).Separate();

        if (commands[0] == "connect")
        {
            string path = commands[1];

            var flagsParser = new FlagsParser(commands);

            string mode = flagsParser.Parse("-m");

            if (mode == "local" || string.IsNullOrEmpty(mode))
            {
                return new ConnectCommand(
                    new LocalConnectionStrategy(new CommandValue(path)),
                    new LocalSystemPathHandler(),
                    new CommandValue(path));
            }
        }

        return NextCommand?.Handle(commandValue);
    }
}