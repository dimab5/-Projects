namespace Itmo.ObjectOrientedProgramming.Lab4.Services.СommandParsers;

public class FlagsParser
{
    private string[] _arguments;

    public FlagsParser(string[] argument)
    {
        _arguments = argument;
    }

    public string Parse(string flag)
    {
        for (int i = 0; i < _arguments.Length - 1; i++)
        {
            if (_arguments[i] == flag)
            {
                return _arguments[i + 1];
            }
        }

        return string.Empty;
    }
}