namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Prototype;

public interface IClonable<T>
    where T : IClonable<T>
{
    T Clone();
}