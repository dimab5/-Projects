using System.Collections.ObjectModel;
using Application.Abstractions.Repositories;
using Application.Contracts.OperationHistories;
using Application.Contracts.Users;
using Application.Models.OperationHistories;
using Application.Models.Users;

namespace Application.App.Users;

internal class UserService : IUserService
{
    private const long SystemPassword = 1;

    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;
    private readonly IOperationHistoryRepository _operationHistoryRepository;

    public UserService(
        IUserRepository repository,
        CurrentUserManager currentUserManager,
        IOperationHistoryRepository operationHistoryRepository)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
        _operationHistoryRepository = operationHistoryRepository;
    }

    public RegistrationResult Registration(string username)
    {
        string action = "Registration";

        Task.Run(async () =>
        {
            await _operationHistoryRepository.AddOperationInHistory(new Operation(
                username,
                " ",
                action,
                OperationResult.Success)).ConfigureAwait(false);

            await _repository.AddUser(username).ConfigureAwait(false);
        }).GetAwaiter().GetResult();

        return new RegistrationResult.Success();
    }

    public LoginResult Login(string username)
    {
        string action = "Login";

        Task<User?> userTask = _repository.FindUserByUsername(username);

        User? user = userTask.Result;

        if (user is null)
        {
            _operationHistoryRepository.AddOperationInHistory(new Operation(
                username,
                " ",
                action,
                OperationResult.Fail)).GetAwaiter().GetResult();

            return new LoginResult.NotFound();
        }

        _operationHistoryRepository.AddOperationInHistory(new Operation(
            username,
            " ",
            action,
            OperationResult.Success)).GetAwaiter().GetResult();

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public AdminLoginResult AdminLogin(long password)
    {
        if (password == SystemPassword)
        {
            User? tmpUser = _currentUserManager.User;

            if (tmpUser != null)
            {
                _currentUserManager.User = new User(tmpUser.Id, tmpUser.Username, UserRole.Admin);
                _repository.UpdateRole(tmpUser, UserRole.Admin);
            }

            return new AdminLoginResult.Success();
        }

        return new AdminLoginResult.WrongPassword();
    }

    public void UserLogin()
    {
        User? tmpUser = _currentUserManager.User;

        if (tmpUser != null)
        {
            _currentUserManager.User = new User(tmpUser.Id, tmpUser.Username, UserRole.User);
            _repository.UpdateRole(tmpUser, UserRole.User);
        }
    }

    public void Logout()
    {
        if (_currentUserManager.User != null)
        {
            Task.Run(async () =>
            {
                await _repository.UpdateRole(_currentUserManager.User, UserRole.Undefined)
                    .ConfigureAwait(false);

                await _operationHistoryRepository.AddOperationInHistory(new Operation(
                    _currentUserManager.User.Username,
                    " ",
                    "Logout",
                    OperationResult.Success)).ConfigureAwait(false);
            }).GetAwaiter().GetResult();
        }

        _currentUserManager.User = null;
    }

    public ReadOnlyCollection<OperationHistory?> ViewOperationHistory()
    {
        if (_currentUserManager?.User?.Username != null)
        {
            List<OperationHistory?> operationHistoryList =
                _operationHistoryRepository.ViewOperationHistory(_currentUserManager.User.Username).Result;

            List<OperationHistory?> filteredList = operationHistoryList?.ToList() ?? new List<OperationHistory?>();

            return new ReadOnlyCollection<OperationHistory?>(filteredList);
        }

        return new ReadOnlyCollection<OperationHistory?>(new List<OperationHistory?>());
    }
}