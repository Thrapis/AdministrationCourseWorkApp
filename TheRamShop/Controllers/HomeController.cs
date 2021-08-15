using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheRamShop.Models.Authentication;
using TheRamShop.Models.DataBase;
using TheRamShop.Models.DataEntities;
using TheRamShop.Models.DataPreparation;
using TheRamShop.Models.DataProviders;
using TheRamShop.Models.PageModels;
using TheRamShop.Models.Statement;

namespace TheRamShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DefaultPreparations.LoadPrimaryInfo(this);


            RamProductProvider productProvider = new RamProductProvider(MRConnection.GetConnection());

            List<ProductCard> products = new List<ProductCard>();
            foreach (RamProduct element in productProvider.GetAll())
            {
                products.Add(new ProductCard(this, element));
            }
            /*products.Add(new ProductInfo("Apple", Url.Action("Product", "Catalog", new { subcategory = "16GB", name = "Apple" }), 8.99m, "$", true, new byte[] { }));
            products.Add(new ProductInfo("Orange", Url.Action("Product", "Catalog", new { subcategory = "8GB", name = "Orange" }), 7.99m, "$", true, new byte[] { }));
            products.Add(new ProductInfo("Pineapple", Url.Action("Product", "Catalog", new { subcategory = "4GB", name = "Pineapple" }), 6.99m, "$", false, new byte[] { }));
            products.Add(new ProductInfo("Kiwi", Url.Action("Product", "Catalog", new { subcategory = "2GB", name = "Kiwi" }), 5.99m, "$", true, new byte[] { }));*/
            ViewBag.ProductList = products;

            return View();
        }
    }
}