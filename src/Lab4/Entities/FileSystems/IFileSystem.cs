using Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.FileShows;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public interface IFileSystem
{
    OperationResult FileShow(IFileShowStrategy fileShowStrategy);
    IComponent? TreeList(int depth, string path);
    OperationResult TreeGoto(CommandValue path);
    OperationResult FileMove(CommandValue sourcePath, CommandValue destinationPath);
    OperationResult FileCopy(CommandValue sourcePath, CommandValue destinationPath);
    OperationResult FileDelete(CommandValue path);
    OperationResult FileRename(CommandValue path, CommandValue name);
}