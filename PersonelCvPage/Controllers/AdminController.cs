using PersonelCvPage.Models.Entity;
using PersonelCvPage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelCvPage.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Login> repo = new GenericRepository<Login>(); // It is another method
        // GET: Skill
        public ActionResult Index()
        {
            var user = repo.List();
            return View(user);
        }
        public ActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(Login p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(int id)
        {
            var user = repo.Find(x => x.ID == id);
            repo.Delete(user);
            return RedirectToAction("Index");
        }
        public ActionResult EditUser(int id)
        {
            var user = repo.Find(x => x.ID == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(Login t)
        {
            var user = repo.Find(x => x.ID == t.ID);
            user.UserName = t.UserName;
            user.Password = t.Password;
            repo.Update(user);
            return RedirectToAction("Index");
        }
    }
}