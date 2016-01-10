using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ToTheLast46.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null, "band", new { controller = "Home", action = "Band" });
            routes.MapRoute(null, "blog", new { controller = "Home", action = "Blog" });
            routes.MapRoute(null, "gigs", new { controller = "Home", action = "Gigs" });
            routes.MapRoute(null, "guestbook", new { controller = "Home", action = "Guestbook" });
            routes.MapRoute(null, "gallery", new { controller = "Home", action = "Gallery" });
            routes.MapRoute(null, "friends", new { controller = "Home", action = "Friends" });
            routes.MapRoute(null, "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
