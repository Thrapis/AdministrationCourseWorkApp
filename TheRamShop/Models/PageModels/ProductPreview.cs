﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheRamShop.Models.DataEntities;

namespace TheRamShop.Models.PageModels
{
    public class ProductPreview
    {
        public string Name { get; private set; }
        public string Url { get; private set; }
        public decimal Cost { get; private set; }
        public string Currency { get; private set; }
        public byte[] Photo { get; private set; }

        public ProductPreview(Controller controller, RamProduct product)
        {
            Name = product.Manufacturer + " " + product.Name;
            Url = controller.Url.Action("Product", "Catalog", new { subcategory = product.Manufacturer, name = product.Name });
            Cost = product.Cost;
            Currency = product.Currency;
            Photo = product.Photo;
        }

        public string GetDotDelimetrCost()
        {
            return Cost.ToString().Replace(",", ".");
        }

        public string GetPrice()
        {
            return Cost.ToString().Replace(",", ".") + Currency;
        }

        public string GetPhotoForPage()
        {
            string base64String = Convert.ToBase64String(Photo, 0, Photo.Length);
            return "data:image/jpg;base64," + base64String;
        }
    }
}