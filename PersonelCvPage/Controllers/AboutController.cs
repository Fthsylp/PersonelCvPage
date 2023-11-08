using PersonelCvPage.Models.Entity;
using PersonelCvPage.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelCvPage.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<About> repo = new GenericRepository<About>();
        // GET: About
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }
        [HttpPost]
        public ActionResult Index(About t, int id)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string ImgFile = "~/Image/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(ImgFile));
                t.Image = "/Image/" + filename + extension;
            }


            var about = repo.Find(x => x.ID == id);
            about.Name = t.Name;
            about.Surname = t.Surname;
            about.Adress = t.Adress;
            about.EMail = t.EMail;
            about.PhoneNumber = t.PhoneNumber;
            about.Description = t.Description;
            about.Image = t.Image;
            repo.Update(about);
            return RedirectToAction("Index");
        }

    }
}