using PersonelCvPage.Models.Entity;
using PersonelCvPage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelCvPage.Controllers
{
    public class InterestController : Controller
    {
        GenericRepository<Interests> repo = new GenericRepository<Interests>(); // It is another method
        // GET: Interest
        public ActionResult Index()
        {
            var hobies = repo.List();
            return View(hobies);
        }
        [HttpPost]
        public ActionResult Index(Interests t, int id)
        {
            var interest = repo.Find(x=>x.ID == id);
            interest.Description = t.Description;
            repo.Update(interest);
            return RedirectToAction("Index");
        }
    }
}