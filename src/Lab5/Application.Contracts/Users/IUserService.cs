using System.Collections.ObjectModel;
using Application.Models.OperationHistories;

namespace Application.Contracts.Users;

public interface IUserService
{
    RegistrationResult Registration(string username);
    LoginResult Login(string username);
    AdminLoginResult AdminLogin(long password);
    void UserLogin();
    void Logout();
    ReadOnlyCollection<OperationHistory?> ViewOperationHistory();
}