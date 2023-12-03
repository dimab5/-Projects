namespace Itmo.ObjectOrientedProgramming.Lab4.Services.PathHandlers;

public interface IPathHandler
{
    string PathHandle(string relativePath, string absolutePath, string pathCommand);
}