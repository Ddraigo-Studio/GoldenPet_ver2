using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoldenPet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("Product", "{type}/{meta}",
             new { controller = "Product", action = "Index", meta = UrlParameter.Optional },
             new RouteValueDictionary
             {
                { "type", "san-pham" }
             },
             namespaces: new[] { "GoldenPet.Controllers" });

            routes.MapRoute("Detail", "{type}/{meta}/{id}",
           new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
           new RouteValueDictionary
           {
                { "type", "san-pham" }
           },
           namespaces: new[] { "GoldenPet.Controllers" });




            routes.MapRoute("Service", "{type}",
          new { controller = "Service", action = "Index", meta = UrlParameter.Optional },
          new RouteValueDictionary
          {
                { "type", "dich-vu" }
          },
          namespaces: new[] { "GoldenPet.Controllers" });

            routes.MapRoute("DetailService", "{type}/{meta}",
          new { controller = "Service", action = "Detail", meta = UrlParameter.Optional },
          new RouteValueDictionary
          {
                { "type", "dich-vu" }
          },
          namespaces: new[] { "GoldenPet.Controllers" });



            routes.MapRoute("News", "{type}/{meta}",
            new { controller = "News", action = "getNews_Index", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "tin-tuc" }
            },
            namespaces: new[] { "GoldenPet.Controllers" });

            //routes.MapRoute("News_Details", "{type}/{meta}/{id}",
            //new { controller = "News", action = "getNew_Details", meta = UrlParameter.Optional },
            //new RouteValueDictionary
            //{
            //    { "type", "tin-tuc" }
            //},
            //namespaces: new[] { "GoldenPet.Controllers" });



            //routes.MapRoute("UserAccount", "{type}/{meta}/{id}",
            //new { controller = "UserAccount", action = "SignUp", id = UrlParameter.Optional, meta = UrlParameter.Optional },
            //new RouteValueDictionary
            //{
            //    { "type", "dang-ky" }
            //},
            //namespaces: new[] { "GoldenPet.Controllers" });

            





            routes.MapRoute("price", "{type}/{meta}",
           new { controller = "Price", action = "Index", meta = UrlParameter.Optional },
           new RouteValueDictionary
           {
                { "type", "goi-dich-vu" }
           },
           namespaces: new[] { "GoldenPet.Controllers" });


            routes.MapRoute("AboutUs", "{type}/{meta}",
            new { controller = "AboutUs", action = "Index", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "thong-tin-ve-chung-toi" }
            },
            namespaces: new[] { "GoldenPet.Controllers" });

           


            routes.MapRoute("Home", "{type}",
            new { controller = "Default", action = "Index", id = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "trang-chu" }
            },
            namespaces: new[] { "GoldenPet.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "GoldenPet.Controllers" }
            );

            
        }
    }
}
