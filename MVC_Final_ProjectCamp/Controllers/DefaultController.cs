using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        ContentManager contentManager = new ContentManager(new EFContentDal());
        public ActionResult Headings()
        {
            var result = headingManager.fetchHeadingList();
            return View(result);
        }
        // GET: Default
        public PartialViewResult Index(int id = 0)
        {
            var result = contentManager.fetchListByHeadId(id);
            return PartialView(result);
        }

        public ActionResult SweetAlert()
        {
            return View();
        }
    }
}