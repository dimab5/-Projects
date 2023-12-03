namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IRepository<T>
{
    void AddComponent(string name, T component);

    T GetComponent(string name);
}