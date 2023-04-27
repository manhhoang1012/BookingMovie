﻿using System.Web.Mvc;

namespace DACS.Areas.Admin
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
                new { action = "Index", Controller = "Phims", id = UrlParameter.Optional }, new[] { "DACS.Areas.Admin.Controllers" }
            );
        }
    }
}