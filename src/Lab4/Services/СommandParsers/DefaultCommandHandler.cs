using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class DefaultCommandHandler : CommandHandlerBase
{
    public override ICommand Handle(CommandValue commandValue)
    {
        return new DefaultCommand();
    }
}