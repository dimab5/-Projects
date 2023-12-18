using Application.Abstractions.Repositories;
using Application.Models.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task AddUser(string username)
    {
        UserRole userRole = UserRole.Undefined;

        const string sql = """
        insert into users (user_name, user_role)
        values (:username, :userRole);
        """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("userRole", userRole);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

    public async Task<User?> FindUserByUsername(string username)
    {
        const string sql = """
        select user_id, user_name, user_role
        from users
        where user_name = :username;
        """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("username", username);

            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (await reader.ReadAsync().ConfigureAwait(false) is false)
                    return null;

                UserRole userRole = await reader.GetFieldValueAsync<UserRole>(2).ConfigureAwait(false);

                return new User(
                    Id: reader.GetInt64(0),
                    Username: reader.GetString(1),
                    Role: userRole);
            }
        }
    }

    public async Task UpdateRole(User user, UserRole userRole)
    {
        const string sql = """
        update users 
        set user_role = :userRole
        where user_id = :userId;
        """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("userRole", userRole);
            command.Parameters.AddWithValue("userId", user.Id);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }
}