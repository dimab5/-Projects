using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;

public interface ILogger
{
    void Log(IMessage message);
}