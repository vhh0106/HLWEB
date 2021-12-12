using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HLWEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            



            routes.MapRoute(
            name: "Home",
            url: "Home",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "Content",
            url: "tin-tuc",
            defaults: new { controller = "Content", action = "Index1", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "Rate",
            url: "danh-gia",
            defaults: new { controller = "Rating", action = "Rating", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "AllProduct",
            url: "danh-sach-san-pham",
            defaults: new { controller = "Product", action = "ListAll", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "Contact",
            url: "lien-he",
            defaults: new { controller = "Contact", action = "Contact", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "Info",
            url: "ve-chung-toi",
            defaults: new { controller = "Info", action = "Index", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "HotProduct",
            url: "san-pham-noi-bat",
            defaults: new { controller = "Product", action = "ListHotProduct", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "ProducByCatId",
            url: "danh-sach-san-pham/{metaTitle}-{id}",
            defaults: new { controller = "Product", action = "ListByCatId", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "Detail",
            url: "Detail/{id}",
            defaults: new { controller = "Order", action = "Detail", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "Product",
            url: "chi-tiet/{metaTitle}-{id}",
            defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "Team",
            url: "nha-sang-lap",
            defaults: new { controller = "Team", action = "Team", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "Register",
            url: "dang-ky",
            defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
            new[] { "DACN.Controllers" }
            );

            routes.MapRoute(
            name: "Login",
            url: "dang-nhap",
            defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
            new[] { "DACN.Controllers" }
            );

            routes.MapRoute(
            name: "CartIndex",
            url: "gio-hang",
            defaults: new { controller = "Cart", action = "CartIndex", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "CartItem",
            url: "them-gio-hang",
            defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "Pay",
            url: "thanh-toan",
            defaults: new { controller = "Cart", action = "Pay", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "Done",
            url: "hoan-thanh",
            defaults: new { controller = "Cart", action = "Done", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            name: "ER",
            url: "loi",
            defaults: new { controller = "Cart", action = "ER", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new[] { "HLWEB.Controllers" }
            );

            

        }
    }
}
