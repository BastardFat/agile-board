using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.Site.Accounts
{
    public static class AccountManager
    {
        public static string CurrentCookie
        {
            get
            {
                if (!HttpContext.Current.Request.Cookies.AllKeys.Contains("__AUTH")) return null;
                return HttpContext.Current.Request.Cookies["__AUTH"].Value;
            }
            set
            {
                HttpContext.Current.Response.Cookies.Set(new HttpCookie("__AUTH", value) { });
            }
        }

        public static void UnsetCookie() =>
            HttpContext.Current.Response.Cookies.Set(new HttpCookie("__AUTH") { Expires = DateTime.Now.AddDays(-1) });
    }
}