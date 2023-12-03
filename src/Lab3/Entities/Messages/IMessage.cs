using Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevels;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public interface IMessage
{
    string Header { get; }
    string Body { get; }
    ImportanceLevel MessageImportanceLevel { get; }
}