using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EFAboutDal());
        public ActionResult Index()
        {
            var aboutValues = abm.fetchAboutList();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About a)
        {
            abm.AboutAddBL(a);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}