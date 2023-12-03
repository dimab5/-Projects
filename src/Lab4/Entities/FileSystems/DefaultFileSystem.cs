using Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.FileShows;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class DefaultFileSystem : IFileSystem
{
    public DefaultFileSystem()
    {
        Directory = new Directory(string.Empty);
        RelativePath = string.Empty;
    }

    public IComponent Directory { get; }
    public string RelativePath { get; }

    public OperationResult FileShow(IFileShowStrategy fileShowStrategy)
    {
        return new OperationResult.Fail("Файловая система не подключена!");
    }

    public IComponent? TreeList(int depth, string path)
    {
        return null;
    }

    public OperationResult TreeGoto(CommandValue path)
    {
        return new OperationResult.Fail("Файловая система не подключена!");
    }

    public OperationResult FileMove(CommandValue sourcePath, CommandValue destinationPath)
    {
        return new OperationResult.Fail("Файловая система не подключена!");
    }

    public OperationResult FileCopy(CommandValue sourcePath, CommandValue destinationPath)
    {
        return new OperationResult.Fail("Файловая система не подключена!");
    }

    public OperationResult FileDelete(CommandValue path)
    {
        return new OperationResult.Fail("Файловая система не подключена!");
    }

    public OperationResult FileRename(CommandValue path, CommandValue name)
    {
        return new OperationResult.Fail("Файловая система не подключена!");
    }
}