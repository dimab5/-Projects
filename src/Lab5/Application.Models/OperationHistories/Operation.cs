using Application.Contracts.OperationHistories;

namespace Application.Models.OperationHistories;

public record Operation(
    string Username,
    string AccountNumber,
    string Action,
    OperationResult Result);