using PersonelCvPage.Models.Entity;
using PersonelCvPage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelCvPage.Controllers
{
    public class SkillController : Controller
    {
        GenericRepository<Skills> repo = new GenericRepository<Skills>(); // It is another method
        // GET: Skill
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        public ActionResult NewSkill() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSkill(Skills p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id) 
        {
            var skill = repo.Find(x => x.ID == id);
            repo.Delete(skill);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateSkill(int id) 
        {
            var skill = repo.Find(x =>x.ID == id);
            return View(skill); 
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skills t)
        {
            var skill = repo.Find(x => x.ID == t.ID);
            skill.Skills1 = t.Skills1;
            skill.Progress = t.Progress;  
            repo.Update(skill);
            return RedirectToAction("Index");
        }
    }
}