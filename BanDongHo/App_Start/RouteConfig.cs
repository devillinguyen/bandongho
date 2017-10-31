using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BanDongHo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Checkout",
                url: "gio-hang/thanh-toan",
                defaults: new { Controller = "Cart", action = "Checkout" }
                );

            routes.MapRoute(
                name: "ListCartItem",
                url: "gio-hang",
                defaults: new { Controller = "Cart", action = "ListCartItem" }
                );

            routes.MapRoute(
                name: "ProductCategory",
                url: "loai-san-pham/{id}",
                defaults: new { Controller = "Categories", action = "ListProduct", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                namespaces: new[] { "BanDongHo.Controllers" }
                );

            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults:new {controller = "Home", action = "About", id = UrlParameter.Optional},
                namespaces:new []{"BanDongHo.Controllers"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
