using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5_proj
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.config");


            routes.MapRoute(
                name: "ShowAbout",
                url: "Home/ShowAbout",
                defaults: new { controller = "Home", action = "ShowAbout", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ShowContact",
                url: "Home/ShowContact",
                defaults: new { controller = "Home", action = "ShowContact", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "Home", action = "ShowHomePage", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "ShowHomePage", id = UrlParameter.Optional }
            );
        }
    }
}
