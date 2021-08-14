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

namespace TheRamShop.Models.DataPreparation
{
    public static class DefaultPreparations
    {
        public static void LoadPrimaryInfo(Controller controller)
        {
            string currentUrl = HttpContext.Current.Request.Url.AbsolutePath;
            controller.ViewBag.CurrentUrl = currentUrl;

            SessionManager sessionManager = new SessionManager(controller.Session);
            RequestManager requestManager = new RequestManager(controller.Request);

            string currency = "USD";
            if (requestManager.HasParamValue("currency"))
            {
                currency = requestManager.GetParamValue("currency");
                sessionManager.AddValue("currency", currency);
            }
            if (sessionManager.HasValue("currency"))
                currency = sessionManager.GetValue("currency").ToString();

            controller.ViewBag.Currency = currency;

            Random random = new Random();

            RamProductProvider productProvider = new RamProductProvider(MRConnection.GetConnection());
            List<RamProduct> ramProducts = productProvider.GetAll().ToList();

            controller.ViewBag.Categories = new List<Hyperlink>();

            controller.ViewBag.Manufacturers = new List<Hyperlink>();

            controller.ViewBag.Bestsellers = new List<Hyperlink>();

            List<Review> reviews = new List<Review>();
            reviews.Add(new Review(new ProductInfo(controller, ramProducts.ElementAt(random.Next(0, ramProducts.Count))),
                "Joe Carter", 3.5f, "Lovely box of crunchy apples and delivered very quickly. Thank You!"));
            controller.ViewBag.ReviewsPreview = reviews;

            controller.ViewBag.WhatsNew = new ProductInfo(controller, ramProducts.ElementAt(random.Next(0, ramProducts.Count)));
        }
    }
}