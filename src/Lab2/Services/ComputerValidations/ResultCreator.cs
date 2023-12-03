using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidations;

public class ResultCreator
{
    private Collection<PossibleResults?> _possibleResults;

    public ResultCreator(Collection<PossibleResults?> possibleResults)
    {
        _possibleResults = possibleResults;
    }

    public PossibleResults CreateResult()
    {
        string result = string.Empty;

        if (_possibleResults.Any(result => result is PossibleResults.Fail))
        {
            foreach (PossibleResults? res in _possibleResults)
            {
                if (res is PossibleResults.Fail failResult)
                {
                    result += failResult.Comments;
                }
            }

            return new PossibleResults.Fail(result);
        }

        if (_possibleResults.Any(result => result is PossibleResults.SuccessWithComments))
        {
            foreach (PossibleResults? res in _possibleResults)
            {
                if (res is PossibleResults.SuccessWithComments successWithCommentsResult)
                {
                    result += successWithCommentsResult.Comments;
                }
            }

            return new PossibleResults.SuccessWithComments(result);
        }

        return new PossibleResults.Success();
    }
}