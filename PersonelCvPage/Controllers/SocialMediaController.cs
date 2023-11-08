using PersonelCvPage.Models.Entity;
using PersonelCvPage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelCvPage.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<SocialMedia> repo = new GenericRepository<SocialMedia>();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var social = repo.List();
            return View(social);
        }
        public ActionResult AddSocial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocial(SocialMedia p)
        {
            if (p.Name == "Instagram")
            {
                p.Sign = "fab fa-instagram";
            }
            else if (p.Name == "Linkedin")
            {
                p.Sign = "fab fa-linkedin-in";
            }
            else if (p.Name == "Facebook")
            {
                p.Sign = "fab fa-facebook-f";
            }
            else if (p.Name == "Twitter")
            {
                p.Sign = "fab fa-twitter";
            }
            else if (p.Name == "GitHub")
            {
                p.Sign = "fab fa-github";
            }
            else 
            {
                p.Sign = "fab fa-question";
            }
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult EditSocial(int id) 
        {
            var social = repo.Find(x=>x.ID == id);
            return View(social);
        }
        [HttpPost]
        public ActionResult EditSocial(SocialMedia t)
        {
            var social = repo.Find(x => x.ID == t.ID);
            social.Name = t.Name;
            social.Link = t.Link;
            if (social.Name == "Instagram")
            {
                social.Sign = "fab fa-instagram";
            }
            else if (social.Name == "Linkedin")
            {
                social.Sign = "fab fa-linkedin-in";
            }
            else if (social.Name == "Facebook")
            {
                social.Sign = "fab fa-facebook-f";
            }
            else if (social.Name == "Twitter")
            {
                social.Sign = "fab fa-twitter";
            }
            else if (social.Name == "GitHub")
            {
                social.Sign = "fab fa-github";
            }
            else
            {
                social.Sign = "fab fa-question";
            }
            social.Status = true;
            repo.Update(social);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocial(int id) 
        {
            var social = repo.Find(x=>x.ID == id);
            social.Status = false;
            repo.Update(social);
            return RedirectToAction("Index");
        }
    }
}