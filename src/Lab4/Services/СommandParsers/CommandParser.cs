using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class CommandParser
{
    private ICommandHandler _commandHandler;

    public CommandParser()
    {
        _commandHandler = new ConnectCommandHandler();

        _commandHandler
            .AddNext(new FileShowCommandHandler())
            .AddNext(new TreeListCommandHandler())
            .AddNext(new DisconnectCommandHandler())
            .AddNext(new TreeGotoCommandHandler())
            .AddNext(new FileDeleteCommandHandler())
            .AddNext(new FileCopyCommandHandler())
            .AddNext(new FileMoveCommandHandler())
            .AddNext(new FileRenameCommandHandler())
            .AddNext(new DefaultCommandHandler());
    }

    public ICommand? Handle(CommandValue command)
    {
        return _commandHandler.Handle(command);
    }
}