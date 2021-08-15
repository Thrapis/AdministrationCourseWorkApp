using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheRamShop.Models.DataEntities;

namespace TheRamShop.Models.PageModels
{
    public class Hyperlink
    {
        public string Name { get; private set; }
        public string Url { get; private set; }

        public Hyperlink(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public Hyperlink(Controller controller, string manufacturer)
        {
            Name = manufacturer;
            Url = controller.Url.Action("Product", "Catalog", new { subcategory = manufacturer });
        }

        public Hyperlink(Controller controller, RamProduct product)
        {
            Name = product.Manufacturer + " " + product.Name;
            Url = controller.Url.Action("Product", "Catalog", new { subcategory = product.Manufacturer, name = product.Name });
        }
    }
}