using Application.Models.Users;

namespace Application.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}