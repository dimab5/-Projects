using Itmo.ObjectOrientedProgramming.Lab1.Models.HealthLevel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.СorpusStrength;

public interface ICorpusStrength
{
    IHealth HealthLevel { get; }
    void GetDamage(int damage);
}