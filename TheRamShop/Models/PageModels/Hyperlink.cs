using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}