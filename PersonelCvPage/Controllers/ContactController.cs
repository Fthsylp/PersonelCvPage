using PersonelCvPage.Models.Entity;
using PersonelCvPage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelCvPage.Controllers
{
    public class ContactController : Controller
    {
        GenericRepository<Comunication> repo = new GenericRepository<Comunication>();
        // GET: Contact
        public ActionResult Index()
        {
            var msg = repo.List();
            return View(msg);
        }
    }
}