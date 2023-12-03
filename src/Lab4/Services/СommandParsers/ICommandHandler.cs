using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public interface ICommandHandler
{
    ICommandHandler AddNext(ICommandHandler commandHandler);
    ICommand? Handle(CommandValue commandValue);
}