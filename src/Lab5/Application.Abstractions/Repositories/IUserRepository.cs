using Application.Models.Users;

namespace Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task AddUser(string username);
    Task<User?> FindUserByUsername(string username);
    Task UpdateRole(User user, UserRole userRole);
}