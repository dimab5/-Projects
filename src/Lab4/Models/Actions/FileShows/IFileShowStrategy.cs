using Itmo.ObjectOrientedProgramming.Lab4.Models.OperationResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Actions.FileShows;

public interface IFileShowStrategy
{
    OperationResult FileShow();
}