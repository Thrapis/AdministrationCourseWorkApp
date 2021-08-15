using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheRamShop.Models.DataEntities
{
    public class Currency
    {
        public string IsoName { get; private set; }
        public string FullName { get; private set; }
        public string Abbreviated { get; private set; }
    }
}