using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TheRamShop.Models.DataEntities;

namespace TheRamShop.Models.DataProviders
{
    public class AuthenticationProvider : IDisposable
    {
        private SqlConnection _connection;

        public AuthenticationProvider(SqlConnection connection)
        {
            _connection = connection;
        }

        public AccountInfo Authenticate(string email, string password)
        {
            return _connection.QueryFirstOrDefault<AccountInfo>($@"execute Authenticate N'{email}', N'{password}'");
        }

        public AccountInfo GetAccountInfo(string email)
        {
            return _connection.QueryFirstOrDefault<AccountInfo>($@"execute GetUserInfoByLogin N'{email}'");
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}