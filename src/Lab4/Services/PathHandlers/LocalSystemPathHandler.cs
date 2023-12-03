using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.PathHandlers;

public class LocalSystemPathHandler : IPathHandler
{
    public string PathHandle(string relativePath, string absolutePath, string pathCommand)
    {
        string relative = Path.Combine(relativePath, pathCommand);
        string absolute = Path.Combine(absolutePath, pathCommand);

        if (Path.Exists(absolute))
        {
            return absolute;
        }

        if (Path.Exists(relative))
        {
            return relative;
        }

        return string.Empty;
    }
}