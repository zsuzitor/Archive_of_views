﻿using System.Web;
using System.Web.Mvc;

namespace Archive_of_views
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
