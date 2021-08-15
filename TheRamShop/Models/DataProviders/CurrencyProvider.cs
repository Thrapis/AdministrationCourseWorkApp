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
            return _connection.Query<Currency>($@"select iso_name IsoName, full_name FullName, abbreviated from Currency");
        }

        public Currency GetCurrencyByIsoName(string isoName)
        {
            return _connection.QueryFirstOrDefault<Currency>($@"select iso_name IsoName, full_name FullName, abbreviated from Currency where ISO_NAME = N'{isoName}'");
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}