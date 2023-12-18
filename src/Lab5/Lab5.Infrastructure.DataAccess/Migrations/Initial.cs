using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_role as enum
        (
            'admin',
            'user',
            'undefined'
        );

        create type operation_result as enum
        (
            'success',
            'fail'
        );

        create table users
        (
            user_id bigint primary key generated always as identity ,
            user_name text not null ,
            user_role user_role not null
        );

        create table bank_account
        (
            bank_account_id bigint primary key generated always as identity ,
            user_id bigint not null references users(user_id) ,
            amount bigint ,
            bank_account_number text not null ,
            pin_code text not null ,
            user_access_role user_role not null
        );
        
        create table operation_history 
        (
            operation_id bigint primary key generated always as identity ,
            user_name text not null ,
            bank_account_number text not null ,
            action text not null ,
            operation_result operation_result not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table users;
        drop table bank_account;
        drop table operation_history;

        drop type user_role;
        drop type operation_result;
        """;
}