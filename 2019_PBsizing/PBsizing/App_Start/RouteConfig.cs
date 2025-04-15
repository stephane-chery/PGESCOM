using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PBsizing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         //  routes.IgnoreRoute("");


            routes.MapRoute(
               "Sizing",
               "Sizing",
               new { Controller = "Sizing", action = "Sizing" });

            routes.MapRoute(
               "STEPS",
               "DispSteps",
               new { Controller = "DispSteps", action = "DispSTEPS" });

            routes.MapRoute(
               "TIERS",
               "DispTiers",
               new { Controller = "DispTiers", action = "DispTIERS" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

            );
        }
    }
}