using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class DefaultCommand : ICommand
{
    public OperationResult Execute(FileSystemContext fileSystemContext)
    {
        return new OperationResult.Fail("Некорректная команда");
    }
}