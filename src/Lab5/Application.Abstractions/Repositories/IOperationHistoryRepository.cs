using Application.Models.OperationHistories;

namespace Application.Abstractions.Repositories;

public interface IOperationHistoryRepository
{
    Task<OperationHistory?> FindHistoryByUsername(string username);
    Task AddOperationInHistory(Operation? operation);
    Task<List<OperationHistory?>> ViewOperationHistory(string username);
}