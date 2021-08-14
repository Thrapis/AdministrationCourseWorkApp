﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TheRamShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Home/Index");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", subcategory = UrlParameter.Optional, name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Special",
                url: "{controller}/{action}/{subcategory}/{*name}",
                defaults: new { controller = "Home", action = "Index", subcategory = UrlParameter.Optional, name = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Start",
                url: "",
                defaults: new { controller = "Home", action = "Index"},
                constraints: new { controller = "Home", action = "Index" }
            );
        }
    }
}
