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
using TheRamShop.Models.DataEntities.Composite;
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

            SessionManager sessionManager = new SessionManager(Session);
            Currency selectedCurrency = (Currency)sessionManager.GetValue("currency");

            RamInfoProvider productProvider = new RamInfoProvider(MRConnection.GetConnection());
            IEnumerable<RamInfo> infos = productProvider.GetAllInCurrency(selectedCurrency);


            List<ProductCard> products = ProductCard.ConvertToProductCards(this, infos).ToList();
            
            ViewBag.ProductList = products;

            return View();
        }
    }
}