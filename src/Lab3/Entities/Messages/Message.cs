using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevels;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message : IMessage
{
    internal Message(
        string header,
        string body,
        ImportanceLevel messageImportanceLevel)
    {
        Header = header;
        Body = body;
        MessageImportanceLevel = messageImportanceLevel;
    }

    public string Header { get; }
    public string Body { get; }
    public ImportanceLevel MessageImportanceLevel { get; }

    public static IMessageBuilder Builder() => new MessageBuilder();

    public override int GetHashCode()
    {
        return HashCode.Combine(Header, Body, MessageImportanceLevel);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        var other = (Message)obj;

        return Header == other.Header &&
               Body == other.Body &&
               MessageImportanceLevel == other.MessageImportanceLevel;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.Append("Header: " + Header + "\n");
        builder.Append("Body: " + Body + "\n");

        return builder.ToString();
    }
}