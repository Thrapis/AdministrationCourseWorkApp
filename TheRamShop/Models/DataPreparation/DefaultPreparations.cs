using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheRamShop.Models.DataProviders;
using TheRamShop.Models.DataEntities;
using TheRamShop.Models.PageModels;
using TheRamShop.Models.Statement;
using TheRamShop.Models.DataBase;
using System.Data.SqlClient;
using TheRamShop.Models.DataEntities.Composite;

namespace TheRamShop.Models.DataPreparation
{
    public static class DefaultPreparations
    {
        public static void LoadPrimaryInfo(Controller controller)
        {
           SqlConnection connection = MRConnection.GetConnection();

            string currency = GetChoosenCurrency(controller, connection);
            controller.ViewBag.Currency = currency;

            controller.ViewBag.CurrencyList = GetCurrencyList(connection);

            controller.ViewBag.Categories = GetCategories(controller, connection);
            
            controller.ViewBag.Manufacturers = GetManufacturers(controller, connection);

            controller.ViewBag.Bestsellers = GetBestsellers(controller, connection, currency);

            controller.ViewBag.ReviewsPreview = GetReviewPreviews(controller, connection, currency);

            controller.ViewBag.WhatsNew = GetWhatsNew(controller, connection, currency);
        }

        private static string GetCurrentUrl() => HttpContext.Current.Request.Url.AbsolutePath;

        private static string GetChoosenCurrency(Controller controller, SqlConnection connection)
        {
            SessionManager sessionManager = new SessionManager(controller.Session);
            RequestManager requestManager = new RequestManager(controller.Request);
            CurrencyProvider currencyProvider = new CurrencyProvider(connection);

            Currency currency = null;

            if (requestManager.HasParamValue("currency"))
            {
                string currencyName = requestManager.GetParamValue("currency");
                currency = currencyProvider.GetCurrencyByIsoName(currencyName);
                sessionManager.AddValue("currency", currency);
            }


            if (sessionManager.HasValue("currency"))
                currency = (Currency)sessionManager.GetValue("currency");
            else
            {
                IEnumerable<Currency> currencies = currencyProvider.GetAll();
                currency = currencies.First();
                sessionManager.AddValue("currency", currency);
            }

            return currency.IsoName;
        }

        private static List<CurrencySelection> GetCurrencyList(SqlConnection connection)
        {
            CurrencyProvider currencyProvider = new CurrencyProvider(connection);
            List<CurrencySelection> currencyList = new List<CurrencySelection>();

            foreach (Currency currency in currencyProvider.GetAll())
            {
                currencyList.Add(new CurrencySelection(GetCurrentUrl(), currency));
            }

            return currencyList;
        }

        private static List<Hyperlink> GetCategories(Controller controller, SqlConnection connection)
        {
            //RamProductProvider productProvider = new RamProductProvider(connection);
            //List<RamProduct> ramProducts = productProvider.GetAll().ToList();

            return new List<Hyperlink>();
        }

        private static List<Hyperlink> GetManufacturers(Controller controller, SqlConnection connection)
        {
            RamProductProvider productProvider = new RamProductProvider(connection);

            List<Hyperlink> manufacturers = new List<Hyperlink>();
            foreach (string element in productProvider.GetAllManufacturers())
            {
                manufacturers.Add(new Hyperlink(controller, element));
            }

            return manufacturers;
        }

        private static List<Hyperlink> GetBestsellers(Controller controller, SqlConnection connection, string currency)
        {
            RamProductProvider productProvider = new RamProductProvider(connection);

            List<Hyperlink> bestsellers = new List<Hyperlink>();
            foreach (RamProduct element in productProvider.GetAllInCurrency(currency))
            {
                bestsellers.Add(new Hyperlink(controller, element));
            }

            return bestsellers;
        }

        private static List<Review> GetReviewPreviews(Controller controller, SqlConnection connection, string currency)
        {
            Random random = new Random();
            
            RamInfoProvider ramInfoProvider = new RamInfoProvider(connection);
            List<RamInfo> ramInfos = ramInfoProvider.GetAllInCurrency(currency).ToList();
            RamInfo ramInfo = ramInfos.ElementAt(random.Next(0, ramInfos.Count));

            List <Review> reviews = new List<Review>();

            ProductPage productPage = new ProductPage(controller, ramInfo);
            reviews.Add(new Review(productPage, "Joe Carter", 3.5f,
                "Lovely box of crunchy apples and delivered very quickly. Thank You!"));

            return reviews;
        }

        private static ProductPreview GetWhatsNew(Controller controller, SqlConnection connection, string currency)
        {
            Random random = new Random();

            RamInfoProvider ramInfoProvider = new RamInfoProvider(connection);
            List<RamInfo> ramInfos = ramInfoProvider.GetAllInCurrency(currency).ToList();

            return new ProductPreview(controller, ramInfos.ElementAt(random.Next(0, ramInfos.Count)));
        }
    }
}