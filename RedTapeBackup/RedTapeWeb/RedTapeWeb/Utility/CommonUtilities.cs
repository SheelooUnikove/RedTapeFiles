using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedTapeWeb.Utility
{
    public class CommonUtilities
    {

        public static string SiteURLback()
        {
            return  System.Configuration.ConfigurationManager.AppSettings["SiteURLback"];
        }
       


    }



}