using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheRamShop.Models.DataEntities
{
    public class RamProduct
    {
        public string Name { get; set; }
        public string Manufacturer{ get; set; }
        public string Type { get; set; }
        public string Volume { get; set; }
        public string Frequency { get; set; }
        public string Voltage { get; set; }
        public byte[] Photo { get; set; }
        public decimal Cost { get; set; }
        public decimal? NewCost { get; set; }
        public string Currency { get; set; }
        public DateTime DateAdded { get; set; }

        public string GetPhotoForPage()
        {
            string base64String = Convert.ToBase64String(Photo, 0, Photo.Length);
            return "data:image/jpg;base64," + base64String;
        } 
    }
}