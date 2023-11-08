using PersonelCvPage.Models.Entity;
using PersonelCvPage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelCvPage.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<Education> repo = new GenericRepository<Education>();
        // GET: Education
        public ActionResult Index()
        {
            var educate = repo.List();
            return View(educate);
        }
        public ActionResult AddEducation() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Education p)
        {
            if(!ModelState.IsValid) 
            {
                return View("AddEducation");
            }
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id) 
        {
            var education = repo.Find( x=> x.ID == id);
            repo.Delete(education);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateEducation(int id) 
        {
            var education = repo.Find(x => x.ID == id);
            return View(education);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Education t)
        {
            if(!ModelState.IsValid) 
            {
                return View("UpdateEducation");
            }

                var education = repo.Find(x => x.ID == t.ID);
                education.Title = t.Title;
                education.SubTitle1 = t.SubTitle1;
                education.SubTitle2 = t.SubTitle2;
                education.Date = t.Date;
                education.GNO = t.GNO;
                repo.Update(education);
                return RedirectToAction("Index");
        }
    }
}