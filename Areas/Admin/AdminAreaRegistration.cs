using System;
using System.Web.Mvc;

namespace GoldenPet.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Default", action ="Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Menu",
                "Menu/{controller}/{action}/{id}",
                new { Controller = "Menu", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}