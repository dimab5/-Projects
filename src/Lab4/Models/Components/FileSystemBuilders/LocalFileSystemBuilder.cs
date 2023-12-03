namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Components.FileSystemBuilders;

public class LocalFileSystemBuilder
{
    public IComponent Build(string rootPath, int maxDepth)
    {
        if (System.IO.File.Exists(rootPath))
        {
            return new File(rootPath);
        }

        var rootDirectory = new Directory(rootPath);
        BuildDirectory(rootDirectory, rootPath, 0, maxDepth);
        return rootDirectory;
    }

    private void BuildDirectory(Directory directory, string path, int currentDepth, int maxDepth)
    {
        if (currentDepth >= maxDepth)
        {
            return;
        }

        foreach (string filePath in System.IO.Directory.GetFiles(path))
        {
            directory.AddComponent(new File(filePath));
        }

        foreach (string subdirectoryPath in System.IO.Directory.GetDirectories(path))
        {
            var subdirectory = new Directory(subdirectoryPath);
            directory.AddComponent(subdirectory);
            BuildDirectory(subdirectory, subdirectoryPath, currentDepth + 1, maxDepth);
        }
    }
}