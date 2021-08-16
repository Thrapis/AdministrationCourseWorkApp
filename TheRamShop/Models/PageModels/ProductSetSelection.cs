using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheRamShop.Models.DataEntities;

namespace TheRamShop.Models.PageModels
{
    public class ProductSetSelection
    {
        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public string Text { get; private set; }
        public int Count { get; private set; }

        public ProductSetSelection(RamSet set)
        {
            Id = set.Id;
            ProductName = set.RamProductName;
            Text = set.SetSize.ToString() + (set.CostChange != 0 ? " (" + Math.Round(set.CostChange, 2) + set.Currency + ")" : "");
            Count = set.Count;
        }

        public static IEnumerable<ProductSetSelection> ConvertToSetSelections(IEnumerable<RamSet> sets)
        {
            List<ProductSetSelection> selections = new List<ProductSetSelection>();

            foreach (RamSet set in sets)
            {
                selections.Add(new ProductSetSelection(set));
            }

            return selections;
        }
    }
}