using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelCvPage.Models.Entity;
namespace PersonelWebSite.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities(); //DbCv is our database name
        public ActionResult Index()
        {
            var values = db.About.ToList();
            return View(values);
        }
        public PartialViewResult SocialMedia() 
        {
            var values = db.SocialMedia.Where(x=>x.Status == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult Experience() // You can only return one table for one page. When you need multiple tables for one page. We use partial view.
        {
            var values = db.Experience.ToList();
            return PartialView(values);
        }
        public PartialViewResult Education()
        {
            var values = db.Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult Skills()
        {
            var values = db.Skills.ToList();
            return PartialView(values);
        }
        public PartialViewResult Interests()
        {
            var values = db.Interests.ToList();
            return PartialView(values);
        }
        public PartialViewResult Certification()
        {
            var values = db.Certification.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult Comunication()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Comunication(Comunication contact)
        {
            contact.Date = DateTime.Now;
            db.Comunication.Add(contact);
            db.SaveChanges();
            return PartialView();
        }
    }
}