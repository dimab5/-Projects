using Directory = Itmo.ObjectOrientedProgramming.Lab4.Models.Components.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Models.Components.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.FileSystemVisitor;

public interface IFileSystemVisitor
{
    void VisitFile(File file);
    void VisitDirectory(Directory directory);
}