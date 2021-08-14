using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRamShop.Models.Statement
{
    public static class CookiesManager
    {
        public static void AddValue(string name, string value)
        {
            HttpCookieCollection cookie = HttpContext.Current.Request.Cookies;
            cookie.Add(new HttpCookie(name, value));
        }

        public static string GetValue(string name)
        {
            HttpCookieCollection cookie = HttpContext.Current.Request.Cookies;
            return cookie.Get(name).Value;
        }

        public static bool HasValue(string name)
        {
            HttpCookieCollection cookie = HttpContext.Current.Request.Cookies;
            return cookie.AllKeys.Contains(name);
        }
    }
}