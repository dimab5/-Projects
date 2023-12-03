using Itmo.ObjectOrientedProgramming.Lab4.Models.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Components;

public interface IComponent
{
    public string Path { get; }
    void Accept(IFileSystemVisitor visitor);
}