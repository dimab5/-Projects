using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.Connections;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;
using Itmo.ObjectOrientedProgramming.Lab4.Services.PathHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class ConnectCommand : ICommand
{
    public ConnectCommand(
        IConnectionStrategy connectionStrategy,
        IPathHandler pathHandler,
        CommandValue path)
    {
        ConectionStrategy = connectionStrategy;
        PathHandler = pathHandler;
        Path = path;
    }

    public IConnectionStrategy ConectionStrategy { get; }
    public IPathHandler PathHandler { get; }
    public CommandValue Path { get; }

    public OperationResult Execute(FileSystemContext fileSystemContext)
    {
        fileSystemContext.FileSystem = ConectionStrategy.Connect();
        fileSystemContext.PathHandler = PathHandler;
        fileSystemContext.RelativePath = Path.Value;
        fileSystemContext.AbsolutePath = Path.Value;

        if (fileSystemContext.FileSystem is DefaultFileSystem)
        {
            return new OperationResult.Fail("Файловая система не подключена!");
        }

        return new OperationResult.Success("Файловая система подключена!");
    }
}