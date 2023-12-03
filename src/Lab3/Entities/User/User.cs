using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User;

public class User : IUser
{
    private List<IMessage> _messages = new();
    private List<IMessage> _unreadMessages = new();

    public User(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public IReadOnlyList<IMessage> Messages => _messages;
    public IReadOnlyList<IMessage> UnreadMessages => _unreadMessages;

    public void ReceiveMessage(IMessage message)
    {
        _messages.Add(message);
        _unreadMessages.Add(message);
    }

    public MessageReadStatus ReadMessage(IMessage message)
    {
        if (_messages.Contains(message) && !_unreadMessages.Contains(message))
        {
            return new MessageReadStatus.AlreadyReadError("Сообщение уже прочитано!");
        }

        _unreadMessages.RemoveAll(mess => mess.Equals(message));
        return new MessageReadStatus.SuccessfullyRead();
    }
}