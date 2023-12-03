namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Components.FileSystemBuilders;

public interface IFileSystemBuilder
{
    IComponent Build(string rootPath, int maxDepth);
}