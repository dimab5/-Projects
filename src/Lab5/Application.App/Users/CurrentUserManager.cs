using Application.Contracts.Users;
using Application.Models.Users;

namespace Application.App.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}