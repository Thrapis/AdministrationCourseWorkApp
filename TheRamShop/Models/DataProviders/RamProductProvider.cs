using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TheRamShop.Models.DataEntities;

namespace TheRamShop.Models.DataProviders
{
    public class RamProductProvider : IDisposable
    {
        private SqlConnection _connection;

        public RamProductProvider(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<RamProduct> GetAll()
        {
            return _connection.Query<RamProduct>($@"select * from Ram_Product");
        }

        public RamProduct GetByName(string name)
        {
            return _connection.QueryFirstOrDefault<RamProduct>($@"select * from Ram_Product where name = N'{name}'");
        }

        public IEnumerable<string> GetAllManufacturers()
        {
            return _connection.Query<string>($@"select distinct Manufacturer from Ram_Product");
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}