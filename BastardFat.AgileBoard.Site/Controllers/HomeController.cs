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
            using (var db = new Database.AgileBoardDBContext())
            {
                db.Users.ToList();

            }

            return View();
        }

    }
}