using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheRamShop.Models.DataEntities;

namespace TheRamShop.Models.PageModels
{
    public class CurrencySelection
    {
        public string ShortName { get; private set; }
        public string LongName { get; private set; }
        public string RedirectAndSetUrl { get; private set; }
        
        public CurrencySelection(string redirectUrl, Currency currency)
        {
            ShortName = currency.IsoName;
            LongName = currency.FullName;
            RedirectAndSetUrl = redirectUrl + $"?currency={currency.IsoName}";
        }
    }
}