using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRamShop.Models.DataEntities.Composite
{
    public class RamInfo
    {
        public RamProduct Product { get; set; }
        public Currency Currency { get; set; }
        public List<RamSet> Sets { get; set; }

        public RamInfo(RamProduct product, Currency currency, IEnumerable<RamSet> sets)
        {
            Product = product;
            Currency = currency;
            Sets = sets.ToList();
        }
    }
}