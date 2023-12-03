using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FileSystemVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class TreeListCommand : ICommand
{
    public TreeListCommand(int depth, IFileSystemVisitor fileSystemVisitor)
    {
        Depth = depth;
        FileSystemVisitor = fileSystemVisitor;
    }

    public int Depth { get; }
    public IFileSystemVisitor FileSystemVisitor { get; }

    public OperationResult Execute(FileSystemContext fileSystemContext)
    {
        IComponent? directory = fileSystemContext.FileSystem.TreeList(
            Depth,
            fileSystemContext.RelativePath);

        directory?.Accept(FileSystemVisitor);

        return new OperationResult.Success("Каталог выведен в виде дерева.");
    }
}