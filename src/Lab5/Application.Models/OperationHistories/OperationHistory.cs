using Application.Contracts.OperationHistories;

namespace Application.Models.OperationHistories;

public record OperationHistory(
    long OperationId,
    string Username,
    string AccountNumber,
    string Action,
    OperationResult Result);