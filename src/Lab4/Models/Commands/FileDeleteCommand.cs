using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileDeleteCommand : ICommand
{
    public FileDeleteCommand(CommandValue path)
    {
        Path = path;
    }

    public CommandValue Path { get; }

    public OperationResult Execute(FileSystemContext fileSystemContext)
    {
        string pathCommand = fileSystemContext.PathHandler.PathHandle(
            fileSystemContext.RelativePath,
            fileSystemContext.AbsolutePath,
            Path.Value);

        if (!string.IsNullOrEmpty(pathCommand))
        {
            return fileSystemContext.FileSystem.FileDelete(Path);
        }

        return new OperationResult.Fail("Такого файла не существует!");
    }
}