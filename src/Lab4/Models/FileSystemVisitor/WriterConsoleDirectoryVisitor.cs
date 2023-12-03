using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Components;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Models.Components.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Models.Components.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.FileSystemVisitor;

public class WriterConsoleDirectoryVisitor : IFileSystemVisitor
{
    private int _depth;
    private WriteSymbols _symbols;

    public WriterConsoleDirectoryVisitor(WriteSymbols symbols)
    {
        _symbols = symbols;
    }

    public void VisitFile(File file)
    {
        PrintIndented($"{_symbols.FileSymbol} {Path.GetFileName(file.Path)}");
    }

    public void VisitDirectory(Directory directory)
    {
        if (_depth == 0)
        {
            PrintIndented($"{_symbols.DirectorySymbols} {directory.Path}");
        }
        else
        {
            PrintIndented($"{_symbols.DirectorySymbols} {Path.GetFileName(directory.Path)}");
        }

        _depth++;

        foreach (IComponent component in directory.Components)
        {
            component.Accept(this);
        }

        _depth--;
    }

    private void PrintIndented(string message)
    {
        Console.WriteLine(new string(_symbols.IndentSymbol, _depth) + message);
    }
}