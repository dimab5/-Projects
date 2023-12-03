using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileRenameCommand : ICommand
{
    public FileRenameCommand(CommandValue path, CommandValue name)
    {
        Path = path;
        Name = name;
    }

    public CommandValue Path { get; }
    public CommandValue Name { get; }

    public OperationResult Execute(FileSystemContext fileSystemContext)
    {
        string pathCommand = fileSystemContext.PathHandler.PathHandle(
            fileSystemContext.RelativePath,
            fileSystemContext.AbsolutePath,
            Path.Value);

        string? fileDirectoryCommand = System.IO.Path.GetDirectoryName(pathCommand);

        if (!string.IsNullOrEmpty(pathCommand) && fileDirectoryCommand is not null)
        {
            string newFilePath = System.IO.Path.Combine(fileDirectoryCommand, Name.Value);

            return fileSystemContext.FileSystem.FileRename(
                new CommandValue(pathCommand),
                new CommandValue(newFilePath));
        }

        return new OperationResult.Fail("Путь не найден!");
    }
}