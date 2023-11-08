using PersonelCvPage.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelCvPage.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login p)
        {
            var user = db.Login.FirstOrDefault(x=> x.UserName == p.UserName && x.Password == p.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["UserName"] = user.UserName.ToString();
                return RedirectToAction("Index", "About");
            }
            else 
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

    }
}