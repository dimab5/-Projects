using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;
using Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var fileSystemContext = new FileSystemContext();
        var commandParser = new CommandParser();

        while (true)
        {
            string? inputCommand = Console.ReadLine();

            if (inputCommand is not null)
            {
                OperationResult? result =
                    commandParser.Handle(new CommandValue(inputCommand))?.Execute(fileSystemContext);

                Console.WriteLine(result?.Message + '\n');
            }
        }
    }
}