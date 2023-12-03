using Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.FileShows;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandSeparators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class FileShowCommandHandler : CommandHandlerBase
{
    public override ICommand? Handle(CommandValue commandValue)
    {
        string[] commands = new CommandSeparator(commandValue).Separate();

        if (commands[0] == "file" && commands[1] == "show")
        {
            string path = commands[2];
            string mode = new FlagsParser(commands).Parse("-m");

            if (mode == "console" || string.IsNullOrEmpty(mode))
            {
                return new FileShowCommand(
                    new CommandValue(path),
                    new ConsoleFileShow(new CommandValue(path)));
            }
        }

        return NextCommand?.Handle(commandValue);
    }
}