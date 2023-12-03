using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class Topic : ITopic
{
    private readonly IAddressee _addressee;

    public Topic(string name, IAddressee addressee)
    {
        Name = name;
        _addressee = addressee;
    }

    public string Name { get; }

    public void GiveMessage(IMessage message)
    {
        _addressee.SendMessage(message);
    }
}