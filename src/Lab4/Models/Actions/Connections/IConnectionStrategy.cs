using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.Connections;

public interface IConnectionStrategy
{
    IFileSystem Connect();
}