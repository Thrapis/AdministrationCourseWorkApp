using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRamShop.Models.DataEntities
{
    public class RamSet
    {
        public int Id { get; set; }
        public string RamProductName { get; set; }
        public int SetSize { get; set; }
        public decimal CostChange { get; set; }
        public string Currency { get; set; }
        public int Count { get; set; }
    }
}