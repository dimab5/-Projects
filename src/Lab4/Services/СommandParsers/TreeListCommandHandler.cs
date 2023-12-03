using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FileSystemVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandSeparators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class TreeListCommandHandler : CommandHandlerBase
{
    public override ICommand? Handle(CommandValue commandValue)
    {
        string[] commands = new CommandSeparator(commandValue).Separate();

        if (commands[0] == "tree" && commands[1] == "list")
        {
            int depth = 1;

            if (commands.Length > 2 &&
                int.TryParse(new FlagsParser(commands).Parse("-d"), out depth))
            {
                return new TreeListCommand(
                    depth,
                    new WriterConsoleDirectoryVisitor(
                        new WriteSymbols('f', 'd', '\t')));
            }

            return new TreeListCommand(
                depth,
                new WriterConsoleDirectoryVisitor(
                    new WriteSymbols('f', 'd', '\t')));
        }

        return NextCommand?.Handle(commandValue);
    }
}