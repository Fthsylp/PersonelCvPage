using PersonelCvPage.Models.Entity;
using PersonelCvPage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelCvPage.Controllers
{
    public class CertificationController : Controller
    {
        GenericRepository<Certification> repo = new GenericRepository<Certification> ();
        // GET: Certification
        public ActionResult Index()
        {
            var certificate = repo.List();
            return View(certificate);
        }
        public ActionResult EditCertificate(int id) 
        {
            var certificate = repo.Find(x=> x.ID == id);
            return View(certificate);
        }
        [HttpPost]
        public ActionResult EditCertificate(Certification t)
        {
            var certificate = repo.Find(x => x.ID == t.ID);
            certificate.Description = t.Description;
            certificate.Date = t.Date;
            repo.Update(certificate);
            return RedirectToAction("Index");
        }
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(Certification p) 
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id) 
        {
            var certificate = repo.Find(x => x.ID == id);
            repo.Delete(certificate);
            return RedirectToAction("Index");
        }
    }
}