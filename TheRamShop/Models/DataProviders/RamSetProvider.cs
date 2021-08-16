using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TheRamShop.Models.DataEntities;

namespace TheRamShop.Models.DataProviders
{
    public class RamSetProvider : IDisposable
    {
        private SqlConnection _connection;

        public RamSetProvider(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<RamSet> GetSetsByName(string name)
        {
            return _connection.Query<RamSet>($@"exec GetSetsByName N'{name}'");
        }

        public IEnumerable<RamSet> GetSetsByNameInCurrency(string name, Currency currency)
        {
            return _connection.Query<RamSet>($@"exec GetSetsByNameInCurrency N'{name}', N'{currency.IsoName}'");
        }

        public IEnumerable<RamSet> GetSetsByProducts(IEnumerable<RamProduct> products)
        {
            List<RamSet> sets = new List<RamSet>();

            foreach (RamProduct product in products)
            {
                sets.AddRange(GetSetsByName(product.Name));
            }

            return sets;
        }

        public IEnumerable<RamSet> GetSetsByProductsInCurrency(IEnumerable<RamProduct> products, Currency currency)
        {
            List<RamSet> sets = new List<RamSet>();

            foreach (RamProduct product in products)
            {
                sets.AddRange(GetSetsByNameInCurrency(product.Name, currency));
            }

            return sets;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}