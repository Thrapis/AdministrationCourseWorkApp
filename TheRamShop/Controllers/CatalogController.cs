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
    public class CatalogController : Controller
    {
        public ActionResult Product(string subcategory = "", string name = "")
        {
            DefaultPreparations.LoadPrimaryInfo(this);

            RequestManager requestManager = new RequestManager(Request);
            if (requestManager.GetParamValue("cmd") == "buy_now")
            {

            }

            SessionManager sessionManager = new SessionManager(Session);
            Currency currency = (Currency)sessionManager.GetValue("currency");

            RamInfoProvider ramInfoProvider = new RamInfoProvider(MRConnection.GetConnection());
            ProductPage product = new ProductPage(this, ramInfoProvider.GetByNameInCurrency(name, currency));

            List<Review> reviews = new List<Review>();
            reviews.Add(new Review(product, "James Lay", 5, "Good staff"));
            reviews.Add(new Review(product, "Proto Coto", 3.5f, "Average product. But thanks!"));
            reviews.Add(new Review(product, "Nikita Nareiko", 1.5f, "Very weak thing"));

            ViewBag.Product = product;
            ViewBag.Reviews = reviews;
            

            return View();
        }

        [HttpPost]
        public ActionResult ToCaret()
        {
            return View();
        }
    }
}