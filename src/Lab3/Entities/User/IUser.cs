using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User;

public interface IUser
{
    string Name { get; }
    void ReceiveMessage(IMessage message);
    MessageReadStatus ReadMessage(IMessage message);
}