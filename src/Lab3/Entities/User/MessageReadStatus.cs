namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User;

public record MessageReadStatus
{
    public record SuccessfullyRead() : MessageReadStatus;

    public record AlreadyReadError(string Error) : MessageReadStatus;
}