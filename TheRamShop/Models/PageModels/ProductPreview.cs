﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheRamShop.Models.DataEntities;
using TheRamShop.Models.DataEntities.Composite;

namespace TheRamShop.Models.PageModels
{
    public class ProductPreview
    {
        public string Name { get; private set; }
        public string Url { get; private set; }
        public decimal Cost { get; private set; }
        public decimal? NewCost { get; private set; }
        public string Currency { get; private set; }
        public string Price { get; private set; }
        public string NewPrice { get; private set; }
        public byte[] Photo { get; private set; }

        public ProductPreview(Controller controller, RamInfo info)
        {
            Name = info.Product.Manufacturer + " " + info.Product.Name;
            Url = controller.Url.Action("Product", "Catalog", new { subcategory = info.Product.Manufacturer, name = info.Product.Name });
            Cost = info.Product.Cost;
            NewCost = info.Product.NewCost;
            Currency = info.Product.Currency;
            Price = Math.Round(Cost, 2).ToString().Replace(",", ".") + info.Currency.Abbreviated;
            if (NewCost != null)
                NewPrice = Math.Round((decimal)NewCost, 2).ToString().Replace(",", ".") + info.Currency.Abbreviated;
            else
                NewPrice = "";
            Photo = info.Product.Photo;
        }

        public string GetDotDelimetrCost()
        {
            return Math.Round(Cost, 2).ToString().Replace(",", ".");
        }

        public string GetPhotoForPage()
        {
            string base64String = Convert.ToBase64String(Photo, 0, Photo.Length);
            return "data:image/jpg;base64," + base64String;
        }
    }
}