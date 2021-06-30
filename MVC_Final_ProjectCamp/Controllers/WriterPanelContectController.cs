using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class WriterPanelContectController : Controller
    {
        // GET: WriterPanelContect
        ContentManager contentManager = new ContentManager(new EFContentDal());
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyContent(string param)
        {
            param = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(w => w.WriterMail == param).Select(x => x.WriterID).FirstOrDefault();
            var contentvalues = contentManager.GetListByWriter(writeridinfo);
            return View(contentvalues);

        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }


        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(w => w.WriterMail == mail).Select(x => x.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writeridinfo;
            content.ContentStatus = true;
            contentManager.ContentAddBL(content);
            return RedirectToAction("MyContent");
        }
    }
}