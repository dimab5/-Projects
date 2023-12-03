using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.Connections;

public class LocalConnectionStrategy : IConnectionStrategy
{
    public LocalConnectionStrategy(CommandValue absolutePath)
    {
        AbsolutePath = absolutePath;
    }

    public CommandValue AbsolutePath { get; }

    public IFileSystem Connect()
    {
        if (Path.Exists(AbsolutePath.Value))
        {
            return new LocalFileSystem();
        }

        return new DefaultFileSystem();
    }
}