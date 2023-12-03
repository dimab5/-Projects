using Itmo.ObjectOrientedProgramming.Lab4.Models.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Components;

public class File : IComponent
{
    public File(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public void Accept(IFileSystemVisitor visitor)
    {
        visitor.VisitFile(this);
    }
}