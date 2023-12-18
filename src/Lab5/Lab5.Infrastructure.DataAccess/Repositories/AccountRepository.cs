using Application.Abstractions.Repositories;
using Application.Models.BankAccounts;
using Application.Models.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<BankAccount?> FindAccountByNumber(string? accountNumber)
    {
        const string sql = """
        select bank_account_id, user_id, amount, bank_account_number, pin_code, user_access_role
        from bank_account
        where bank_account_number = :bank_account_number;
        """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("bank_account_number", accountNumber);

            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (await reader.ReadAsync().ConfigureAwait(false) is false)
                    return null;

                UserRole userRole = await reader.GetFieldValueAsync<UserRole>(5).ConfigureAwait(false);

                return new BankAccount(
                    BankAccountId: reader.GetInt64(0),
                    UserId: reader.GetInt64(1),
                    Amount: reader.GetInt64(2),
                    AccountNumber: reader.GetString(3),
                    PinCode: reader.GetString(4),
                    UserAccessRole: userRole);
            }
        }
    }

    public async Task CreateAccount(Account bankAccount)
    {
        const string sql = """
        insert into bank_account (user_id, amount, bank_account_number, pin_code, user_access_role)
        values (:user_id, :amount, :bank_account_number, :pin_code, :user_access_role);
        """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("user_id", bankAccount.UserId);
            command.Parameters.AddWithValue("amount", bankAccount.Amount);
            command.Parameters.AddWithValue("bank_account_number", bankAccount.AccountNumber);
            command.Parameters.AddWithValue("pin_code", bankAccount.PinCode);
            command.Parameters.AddWithValue("user_access_role", bankAccount.UserAccessRole);

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }

    public async Task ChangeAmounMoney(string? accountNumber, long amount)
    {
        const string sql = """
        update bank_account
        set amount = :amountMoney
        where bank_account_number = :accountNumber;
        """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("amountMoney", amount);

            if (accountNumber != null)
            {
                command.Parameters.AddWithValue("accountNumber", accountNumber);
            }

            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }
}