using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SearchFilghts.Assignment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "searchFlights",
                url: "searchFlights/{origin}/{destination}",
                defaults: new { controller = "searchFlights", action = "Index"  }
            );
            routes.MapRoute(
                name: "IncompleteParameter",
                url: "searchFlights/{origin}",
                defaults: new { controller = "InvalidRequest", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "IncompleteParameter1",
                url: "searchFlights",
                defaults: new { controller = "InvalidRequest", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "IncompleteParameter2",
               url: "{searchFlights}",
               defaults: new { controller = "InvalidRequest", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "InvalidRequest", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}