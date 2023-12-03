using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messanger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeMessanger : IAddressee
{
    private readonly IMessanger _messanger;

    public AddresseeMessanger(IMessanger messanger)
    {
        _messanger = messanger;
    }

    public void SendMessage(IMessage message)
    {
        _messanger.Write(message);
    }
}