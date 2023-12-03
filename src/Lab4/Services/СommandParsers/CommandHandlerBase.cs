using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public abstract class CommandHandlerBase : ICommandHandler
{
    protected ICommandHandler? NextCommand { get; private set; }

    public ICommandHandler AddNext(ICommandHandler commandHandler)
    {
        NextCommand = commandHandler;
        return commandHandler;
    }

    public abstract ICommand? Handle(CommandValue commandValue);
}