using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevels;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Filtering;

public class AddresseeFilterProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ImportanceLevel _importanceLevel;

    public AddresseeFilterProxy(IAddressee addressee, ImportanceLevel importanceLevel)
    {
        _addressee = addressee;
        _importanceLevel = importanceLevel;
    }

    public void SendMessage(IMessage message)
    {
        if (message.MessageImportanceLevel.Priority >= _importanceLevel.Priority)
        {
            _addressee.SendMessage(message);
        }
    }
}