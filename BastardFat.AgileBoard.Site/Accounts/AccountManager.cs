using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BastardFat.AgileBoard.Site.Database.Tables;

namespace BastardFat.AgileBoard.Site.Accounts
{
    public static class AccountManager
    {
        public const string AuthCoockieName = "__AUTH";
        public static string CurrentCookie
        {
            get
            {
                if (!HttpContext.Current.Request.Cookies.AllKeys.Contains(AuthCoockieName)) return null;
                return HttpContext.Current.Request.Cookies[AuthCoockieName].Value;
            }
            set
            {
                HttpContext.Current.Response.Cookies.Set(new HttpCookie(AuthCoockieName, value) { });
            }
        }

        public static void UnsetCookie() =>
            HttpContext.Current.Response.Cookies.Set(new HttpCookie(AuthCoockieName) { Expires = DateTime.Now.AddDays(-1) });
        public static User CurrentUser
        {
            get
            {
                if (CurrentCookie == null) return null;
                using (var db = new Database.AgileBoardDBManager())
                {
                    User SearchResut;
                    if (!db.UserDBController.CheckLogin(Support.CryptHelper.DecodeAndSplit(CurrentCookie)[0], Support.CryptHelper.DecodeAndSplit(CurrentCookie)[1], out SearchResut))
                        return null;
                    CurrentRole = SearchResut.Role;
                    return SearchResut;
                }
            }
            set
            {
                if (value == null)
                {
                    UnsetCookie();
                    return;
                }
                CurrentCookie = Support.CryptHelper.JoinAndEncode(new[] { value.Name, value.PasswordHash });
            }
        }

       public static bool Register(string Name, string Password)
        {
            if (String.IsNullOrEmpty(Name)) return false;
            if (String.IsNullOrEmpty(Password)) return false;

            using (var db = new Database.AgileBoardDBManager())
            {
                if (db.UserDBController.Get(Name) == null)
                {
                    db.UserDBController.Add(Name, Support.CryptHelper.SHA1(Password), "User");
                    return Login(Name, Password);
                }
                return false;
            }
        }

        private static Role currentRole;

        public static Role CurrentRole
        {
            get { return currentRole; }
            set { currentRole = value; }
        }


        public static bool Login(string Name, string Password)
        {
            if (String.IsNullOrEmpty(Name)) return false;
            if (String.IsNullOrEmpty(Password)) return false;

            using (var db = new Database.AgileBoardDBManager())
            {
                User SearchResut;
                if (db.UserDBController.CheckLogin(Name, Support.CryptHelper.SHA1(Password), out SearchResut))
                {
                    CurrentUser = SearchResut;
                    return true;
                }
                return false;
            }
        }
    }
}