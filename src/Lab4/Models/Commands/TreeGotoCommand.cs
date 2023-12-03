using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class TreeGotoCommand : ICommand
{
    public TreeGotoCommand(CommandValue path)
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
            fileSystemContext.RelativePath = pathCommand;

            Console.WriteLine(fileSystemContext.RelativePath);

            return fileSystemContext.FileSystem.TreeGoto(Path);
        }

        return new OperationResult.Fail("Путь не найден!");
    }
}