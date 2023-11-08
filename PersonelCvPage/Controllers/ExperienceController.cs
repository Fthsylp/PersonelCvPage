using PersonelCvPage.Models.Entity;
using PersonelCvPage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelCvPage.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repo = new ExperienceRepository();
        // GET: Experience
        public ActionResult Index()
        {
            var exp = repo.List();
            return View(exp);
        }
        public ActionResult AddExp() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExp(Experience p) 
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExp(int id)
        {
            Experience exp = repo.Find(x => x.ID == id);
            repo.Delete(exp);
            return RedirectToAction("Index");
        }
        public ActionResult ShowExp(int id) 
        {
            Experience exp = repo.Find(x => x.ID == id);
            return View(exp);
        }
        [HttpPost]
        public ActionResult ShowExp(Experience p)
        {
            Experience exp = repo.Find(x => x.ID == p.ID);
            exp.Title = p.Title;
            exp.SubTitle = p.SubTitle;
            exp.Date = p.Date;
            exp.Description = p.Description;
            repo.Update(exp);
            return RedirectToAction("Index");
        }
    }
}