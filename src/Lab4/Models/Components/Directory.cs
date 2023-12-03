using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Components;

public class Directory : IComponent
{
    private List<IComponent> _components = new();

    public Directory(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public IReadOnlyList<IComponent> Components => _components;

    public void AddComponent(IComponent component)
    {
        _components.Add(component);
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        visitor.VisitDirectory(this);
    }
}