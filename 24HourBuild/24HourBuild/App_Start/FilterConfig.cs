﻿using System.Web;
using System.Web.Mvc;

namespace _24HourBuild
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
