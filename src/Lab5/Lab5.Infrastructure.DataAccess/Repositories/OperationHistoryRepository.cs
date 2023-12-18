using Application.Abstractions.Repositories;
using Application.Contracts.OperationHistories;
using Application.Models.OperationHistories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class OperationHistoryRepository : IOperationHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationHistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<OperationHistory?> FindHistoryByUsername(string username)
    {
        const string sql =
        """
        select operation_id, user_name, bank_account_number, action, operation_result
        from operation_history
        where user_name = :user_name;
        """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("user_name", username);

            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (await reader.ReadAsync().ConfigureAwait(false) is false)
                    return null;

                OperationResult operationResult = await reader.GetFieldValueAsync<OperationResult>(4).ConfigureAwait(false);

                return new OperationHistory(
                    OperationId: reader.GetInt64(0),
                    Username: reader.GetString(1),
                    AccountNumber: reader.GetString(2),
                    Action: reader.GetString(3),
                    Result: operationResult);
            }
        }
    }

    public async Task AddOperationInHistory(Operation? operation)
    {
        const string sql = """
        insert into operation_history (user_name, bank_account_number, action, operation_result)
        values (:user_name, :bank_account_number, :action, :operation_result);
        """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            if (operation != null)
            {
                command.Parameters.AddWithValue("user_name", operation.Username);
                command.Parameters.AddWithValue("bank_account_number", operation.AccountNumber);
                command.Parameters.AddWithValue("action", operation.Action);
                command.Parameters.AddWithValue("operation_result", operation.Result);
            }

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

    public async Task<List<OperationHistory?>> ViewOperationHistory(string username)
    {
        const string sql = """
        select operation_id, user_name, bank_account_number, action, operation_result
        from operation_history
        where user_name = :username;
        """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("username", username);

            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                var result = new List<OperationHistory?>();

                while (await reader.ReadAsync().ConfigureAwait(false))
                {
                    OperationResult operationResult =
                        await reader.GetFieldValueAsync<OperationResult>(4).ConfigureAwait(false);

                    result.Add(new OperationHistory(
                        OperationId: reader.GetInt64(0),
                        Username: reader.GetString(1),
                        AccountNumber: reader.GetString(2),
                        Action: reader.GetString(3),
                        Result: operationResult));
                }

                return result;
            }
        }
    }
}