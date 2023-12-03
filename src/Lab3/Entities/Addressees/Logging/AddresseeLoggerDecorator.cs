using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Logging;

public class AddresseeLoggerDecorator : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public AddresseeLoggerDecorator(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void SendMessage(IMessage message)
    {
        _addressee.SendMessage(message);
        _logger.Log(message);
    }
}