using Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDriver;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class MessageDisplay : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public MessageDisplay(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void Write(IMessage message)
    {
        _displayDriver.ClearOutput();
        _displayDriver.OutputText(message);
    }
}