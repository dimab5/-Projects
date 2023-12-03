using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandSeparators;

public class CommandSeparator
{
    private CommandValue _commandValue;

    public CommandSeparator(CommandValue commandValue)
    {
        _commandValue = commandValue;
    }

    public string[] Separate()
    {
        string commands = _commandValue.Value;

        string[] ansCommands = commands.Split(' ');

        return ansCommands;
    }
}