﻿using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
