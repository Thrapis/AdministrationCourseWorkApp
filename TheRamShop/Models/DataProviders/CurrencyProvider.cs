using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TheRamShop.Models.DataEntities;

namespace TheRamShop.Models.DataProviders
{
    public class CurrencyProvider : IDisposable
    {
        private SqlConnection _connection;

        public CurrencyProvider(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Currency> GetAll()
        {
            return _connection.Query<Currency>($@"exec GetAllCurrencies");
        }

        public Currency GetCurrencyByIsoName(string isoName)
        {
            return _connection.QueryFirstOrDefault<Currency>($@"exec GetCurrencyByIsoName N'{isoName}'");
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}