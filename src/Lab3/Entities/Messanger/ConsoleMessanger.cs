using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messanger;

public class ConsoleMessanger : IMessanger
{
    public void Write(IMessage message)
    {
        Console.WriteLine("(Messanger)\n" + message.ToString() + "\n");
    }
}