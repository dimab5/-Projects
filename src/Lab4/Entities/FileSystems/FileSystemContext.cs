using Itmo.ObjectOrientedProgramming.Lab4.Services.PathHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class FileSystemContext
{
    public FileSystemContext()
    {
        FileSystem = new DefaultFileSystem();
        PathHandler = new DefaultSystemPathHandler();
        AbsolutePath = string.Empty;
        RelativePath = string.Empty;
    }

    public IFileSystem FileSystem { get; set; }
    public IPathHandler PathHandler { get; set; }
    public string AbsolutePath { get; set; }
    public string RelativePath { get; set; }
}