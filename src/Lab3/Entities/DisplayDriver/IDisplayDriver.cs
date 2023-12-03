using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDriver;

public interface IDisplayDriver
{
    void ClearOutput();
    void OutputText(IMessage message);
    void SetColor(Color color);
}