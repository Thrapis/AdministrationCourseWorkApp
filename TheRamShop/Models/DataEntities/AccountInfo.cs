using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRamShop.Models.DataEntities
{
    public class AccountInfo
    {
        public string Login { get; set; }
        public string FullName { get; set; }
        public int AccessLevel { get; set; }
        public byte[] Photo { get; set; }

        public string GetPhotoForPage()
        {
            string base64String = Convert.ToBase64String(Photo, 0, Photo.Length);
            return "data:image/jpg;base64," + base64String;
        }
    }
}