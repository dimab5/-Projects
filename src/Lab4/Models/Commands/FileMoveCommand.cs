using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileMoveCommand : ICommand
{
    public FileMoveCommand(CommandValue sourcePath, CommandValue destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public CommandValue SourcePath { get; }
    public CommandValue DestinationPath { get; }

    public OperationResult Execute(FileSystemContext fileSystemContext)
    {
        string source = fileSystemContext.PathHandler.PathHandle(
            fileSystemContext.RelativePath,
            fileSystemContext.AbsolutePath,
            SourcePath.Value);

        string destination = fileSystemContext.PathHandler.PathHandle(
            fileSystemContext.RelativePath,
            fileSystemContext.AbsolutePath,
            DestinationPath.Value);

        if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(destination))
        {
            return new OperationResult.Fail("Некорректные пути!");
        }

        destination = Path.Combine(destination, Path.GetFileName(source));

        return fileSystemContext.FileSystem.FileMove(
            new CommandValue(source),
            new CommandValue(destination));
    }
}