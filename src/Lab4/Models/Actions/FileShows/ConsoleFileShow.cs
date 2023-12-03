using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.FileShows;

public class ConsoleFileShow : IFileShowStrategy
{
    private CommandValue _path;

    public ConsoleFileShow(CommandValue path)
    {
        _path = path;
    }

    public OperationResult FileShow()
    {
        Console.WriteLine(File.ReadAllText(_path.Value));

        return new OperationResult.Success("Сожержимое файла выведено на консоль!");
    }
}