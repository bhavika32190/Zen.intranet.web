using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Zen.intranet.web.Models;

namespace Zen.intranet.web.Controllers
{
    public class HomeController : Controller
    {
        DBContext _dbContext = new DBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = _dbContext.Users
                    .Any(u => u.UserName.ToLower() == user
                    .UserName.ToLower() && user
                    .Password == user.Password);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Employee");
                }
            }
            ModelState.AddModelError("", "Invalid UserName & Password");
            return View();
        }

        private bool GetIsValidUser(User user)
        {
            return _dbContext.Users
                            .Any(u => u.UserName.ToLower() == user
                            .UserName.ToLower() && user
                            .Password == user.Password);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
    }
}   