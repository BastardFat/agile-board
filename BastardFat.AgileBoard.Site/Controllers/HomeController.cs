using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BastardFat.AgileBoard.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Board()
        {
            if (Accounts.AccountManager.CurrentUser == null) return RedirectToAction(nameof(Login));
            using (var db = new Database.AgileBoardDBContext())
            {
                List<Database.Tables.Task> model = db.Tasks.ToList().Where(t => t.UserId == Accounts.AccountManager.CurrentUser?.Id).ToList();
                return View(model);
            }
        }

        public ActionResult Login(bool fail = false)
        {
            return View(fail);
        }
        public ActionResult Register(bool fail = false)
        {
            return View(fail);
        }
        public ActionResult ChangePassword(bool fail = false, bool success = false)
        {
            return View(new Tuple<bool, bool>(fail, success));
        }


        public ActionResult TryLogin(string user_login, string user_password)
        {
            if (Accounts.AccountManager.Login(user_login, user_password))
                return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Login), new { fail = true });
        }


        public ActionResult TryRegister(string user_login, string user_password, string user_password_1)
        {
            if(user_password != user_password_1) return RedirectToAction(nameof(Register), new { fail = true });
            if (Accounts.AccountManager.Register(user_login, user_password))
                return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Register), new { fail = true });
        }


        public ActionResult TryChangePassword(string old_password, string new_password, string new_password_1)
        {
            if (Accounts.AccountManager.CurrentUser == null) return RedirectToAction(nameof(Login));
            var userName = Accounts.AccountManager.CurrentUser.Name;
            if (new_password != new_password_1) return RedirectToAction(nameof(ChangePassword), new { fail = true });
            using (var db = new Database.AgileBoardDBManager())
            {
                if (Accounts.AccountManager.CurrentUser.PasswordHash != Support.CryptHelper.SHA1(old_password))
                    return RedirectToAction(nameof(ChangePassword), new { fail = true });
                db.UserDBController.ChangePassword(userName, Support.CryptHelper.SHA1(new_password));
            }
            if (Accounts.AccountManager.Login(userName, new_password))
                return RedirectToAction(nameof(ChangePassword), new { success = true });
            return RedirectToAction(nameof(ChangePassword), new { fail = true });
        }


        public ActionResult Logout()
        {
            Accounts.AccountManager.CurrentUser = null;
            return RedirectToAction(nameof(Login));
        }

        public ActionResult Archive()
        {
            if (Accounts.AccountManager.CurrentUser == null) return RedirectToAction(nameof(Login));
            using (var db = new Database.AgileBoardDBManager())
            {
                List<Database.Tables.Task> model = db.TaskDBController.GetAll().ToList().Where(t => t.UserId == Accounts.AccountManager.CurrentUser?.Id && t.Stage == 3).ToList();
                return View(model);
            }
        }

        public ActionResult Users()
        {
            if(Accounts.AccountManager.CurrentUser == null || Accounts.AccountManager.CurrentUser?.Role?.IsAdmin == false) return RedirectToAction(nameof(Index));
            using (var db = new Database.AgileBoardDBManager())
            {
                var model = db.UserDBController.GetAll().ToList();
                return View(model);
            }
        }



    }
}