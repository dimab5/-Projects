using Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevels;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public interface IMessageBuilder
{
    IMessageBuilder WithHeader(string? header);
    IMessageBuilder WithBody(string? body);
    IMessageBuilder WithImportanceLevel(ImportanceLevel? importanceLevel);
    IMessage Build();
}