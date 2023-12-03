using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevels;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class MessageBuilder : IMessageBuilder
{
    private string? _header;
    private string? _body;
    private ImportanceLevel? _importanceLevel;

    public IMessageBuilder WithHeader(string? header)
    {
        _header = header;
        return this;
    }

    public IMessageBuilder WithBody(string? body)
    {
        _body = body;
        return this;
    }

    public IMessageBuilder WithImportanceLevel(ImportanceLevel? importanceLevel)
    {
        _importanceLevel = importanceLevel;
        return this;
    }

    public IMessage Build()
    {
        return new Message(
            _header ?? throw new InvalidOperationException(),
            _body ?? throw new InvalidOperationException(),
            _importanceLevel ?? throw new InvalidOperationException());
    }
}