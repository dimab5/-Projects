using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDriver;

public class MessageDisplayDriver : IDisplayDriver
{
    private Color _color;

    public void ClearOutput()
    {
        Console.Clear();
    }

    public void OutputText(IMessage message)
    {
        Console.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B)
            .Text(message.ToString() ?? string.Empty));
    }

    public void SetColor(Color color)
    {
        _color = color;
    }
}