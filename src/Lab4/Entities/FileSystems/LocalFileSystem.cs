using Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.FileShows;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Components.FileSystemBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public OperationResult FileShow(IFileShowStrategy fileShowStrategy)
    {
        return fileShowStrategy.FileShow();
    }

    public IComponent TreeList(int depth, string path)
    {
        return new LocalFileSystemBuilder().Build(path, depth);
    }

    public OperationResult TreeGoto(CommandValue path)
    {
        return new OperationResult.Success("Перемещение выполнено.");
    }

    public OperationResult FileMove(CommandValue sourcePath, CommandValue destinationPath)
    {
        File.Move(sourcePath.Value, destinationPath.Value);

        return new OperationResult.Success("Файл перемещён.");
    }

    public OperationResult FileCopy(CommandValue sourcePath, CommandValue destinationPath)
    {
        File.Copy(sourcePath.Value, destinationPath.Value);

        return new OperationResult.Success("Файл скопирован.");
    }

    public OperationResult FileDelete(CommandValue path)
    {
        File.Delete(path.Value);

        return new OperationResult.Success("Файл удалён.");
    }

    public OperationResult FileRename(CommandValue path, CommandValue name)
    {
        File.Move(name.Value, path.Value);

        return new OperationResult.Success("Файл переименован.");
    }
}