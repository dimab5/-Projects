using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.FileShows;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileShowCommand : ICommand
{
    public FileShowCommand(CommandValue path, IFileShowStrategy fileShowStrategy)
    {
        Path = path;
        FileShowStrategy = fileShowStrategy;
    }

    public CommandValue Path { get; }
    public IFileShowStrategy FileShowStrategy { get; }

    public OperationResult Execute(FileSystemContext fileSystemContext)
    {
        string pathResult = fileSystemContext.PathHandler.PathHandle(
            fileSystemContext.RelativePath,
            fileSystemContext.AbsolutePath,
            Path.Value);

        if (string.IsNullOrEmpty(pathResult))
        {
            return new OperationResult.Fail("Не существует такого пути!");
        }

        return fileSystemContext.FileSystem.FileShow(FileShowStrategy);
    }
}