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
    public class RamInfoProvider : IDisposable
    {
        private SqlConnection _connection;

        public RamInfoProvider(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<RamInfo> GetAll()
        {
            List<RamInfo> infos = new List<RamInfo>();

            foreach (RamProduct product in _connection.Query<RamProduct>($@"exec GetAllRamProducts"))
            {
                Currency currency = _connection.QueryFirstOrDefault<Currency>($@"exec GetCurrencyByIsoName N'{product.Currency}'");
                IEnumerable<RamSet> sets = _connection.Query<RamSet>($@"exec GetSetsByNameInCurrency N'{product.Name}', N'{currency.IsoName}'");
                
                infos.Add(new RamInfo(product, currency, sets));
            }

            return infos;
        }
        
        public IEnumerable<RamInfo> GetAllInCurrency(string isoName)
        {
            List<RamInfo> infos = new List<RamInfo>();

            Currency currency = _connection.QueryFirstOrDefault<Currency>($@"exec GetCurrencyByIsoName N'{isoName}'");
            
            foreach (RamProduct product in _connection.Query<RamProduct>($@"exec GetAllRamProductsInCurrency N'{isoName}'"))
            {
                IEnumerable<RamSet> sets = _connection.Query<RamSet>($@"exec GetSetsByNameInCurrency N'{product.Name}', N'{currency.IsoName}'");
                infos.Add(new RamInfo(product, currency, sets));
            }

            return infos;
        }

        public IEnumerable<RamInfo> GetAllInCurrency(Currency currency)
        {
            List<RamInfo> infos = new List<RamInfo>();

            foreach (RamProduct product in _connection.Query<RamProduct>($@"exec GetAllRamProductsInCurrency N'{currency.IsoName}'"))
            {
                IEnumerable<RamSet> sets = _connection.Query<RamSet>($@"exec GetSetsByNameInCurrency N'{product.Name}', N'{currency.IsoName}'");
                infos.Add(new RamInfo(product, currency, sets));
            }

            return infos;
        }

        public RamInfo GetByName(string name)
        {
            RamProduct product = _connection.QueryFirstOrDefault<RamProduct>($@"select * from Ram_Product where name = N'{name}'");
            IEnumerable<RamSet> sets = _connection.Query<RamSet>($@"exec GetSetsByName N'{product.Name}'");
            Currency currency = _connection.QueryFirstOrDefault<Currency>($@"exec GetCurrencyByIsoName N'{product.Currency}'");

            return new RamInfo(product, currency, sets);
        }

        public RamInfo GetByNameInCurrency(string name, string isoName)
        {
            Currency currency = _connection.QueryFirstOrDefault<Currency>($@"exec GetCurrencyByIsoName N'{isoName}'");
            RamProduct product = _connection.QueryFirstOrDefault<RamProduct>($@"exec GetRamProductByNameInCurrency N'{name}', N'{isoName}'");
            IEnumerable<RamSet> sets = _connection.Query<RamSet>($@"exec GetSetsByNameInCurrency N'{product.Name}', N'{currency.IsoName}'");

            return new RamInfo(product, currency, sets);
        }

        public RamInfo GetByNameInCurrency(string name, Currency currency)
        {
            RamProduct product = _connection.QueryFirstOrDefault<RamProduct>($@"exec GetRamProductByNameInCurrency N'{name}', N'{currency.IsoName}'");
            IEnumerable<RamSet> sets = _connection.Query<RamSet>($@"exec GetSetsByNameInCurrency N'{product.Name}', N'{currency.IsoName}'");

            return new RamInfo(product, currency, sets);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}