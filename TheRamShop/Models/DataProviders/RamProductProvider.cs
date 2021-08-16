using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TheRamShop.Models.DataEntities;
using TheRamShop.Models.DataEntities.Composite;

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
            return _connection.Query<RamProduct>($@"exec GetAllRamProducts");
        }
        
        public IEnumerable<RamProduct> GetAllInCurrency(string isoName)
        {
            return _connection.Query<RamProduct>($@"exec GetAllRamProductsInCurrency N'{isoName}'");
        }

        public IEnumerable<RamProduct> GetAllInCurrency(Currency currency)
        {
            return _connection.Query<RamProduct>($@"exec GetAllRamProductsInCurrency N'{currency.IsoName}'");
        }

        public RamProduct GetByName(string name)
        {
            return _connection.QueryFirstOrDefault<RamProduct>($@"exec GetRamProductByName N'{name}'");
        }

        public IEnumerable<string> GetAllManufacturers()
        {
            return _connection.Query<string>($@"exec GetAllManufacturers");
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}