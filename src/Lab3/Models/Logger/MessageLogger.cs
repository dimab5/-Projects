using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;

public class MessageLogger : ILogger
{
    private readonly IMessage _message;

    public MessageLogger(IMessage message)
    {
        _message = message;
    }

    public void Log(IMessage message)
    {
        Console.WriteLine(_message.ToString() + "(Logger)\n");
    }
}