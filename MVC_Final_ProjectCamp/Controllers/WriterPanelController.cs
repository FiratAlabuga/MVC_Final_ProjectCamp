using Business.Concrete;
using Business.ValidationRules_FV;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        Context context = new Context();
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        WriterValidator writerValidator = new WriterValidator();
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        [HttpGet]
        public ActionResult WriterProfileIndex(int id = 0)
        {
            string param = (string)Session["WriterMail"];
            ViewBag.d = param;
            id = context.Writers.Where(w => w.WriterMail == param).Select(x => x.WriterID).FirstOrDefault();
            var result = writerManager.GetByID(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult WriterProfileIndex()
        {
            return View();
        }
        public ActionResult MyHeading(string param)
        {
            param = (string)Session["WriterMail"];
            var writerid = context.Writers.Where(w => w.WriterMail == param).Select(x => x.WriterID).FirstOrDefault();
            var result = headingManager.GetHeadingByWriter(writerid);
            return View(result);
        }
        [HttpGet]
        public ActionResult HeadingAddForWriter()
        {
            List<SelectListItem> valuecategory = (from c in categoryManager.fetchCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.valuecategory = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult HeadingAddForWriter(Heading heading)
        {
            string deger = (string)Session["WriterEmail"];
            var writeridhead = context.Writers.Where(w => w.WriterMail == deger).Select(x => x.WriterID).FirstOrDefault();
            heading.HeadDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writeridhead;
            heading.HeadStatus = true;
            headingManager.HeadingAddBL(heading);
            return RedirectToAction("MyHeading");

        }

        [HttpGet]
        public ActionResult UpdateHeadingForWriter(int id)
        {
            List<SelectListItem> valuecategory = (from c in categoryManager.fetchCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryID.ToString()

                                                  }).ToList();

            ViewBag.valuecategory = valuecategory;
            var result = headingManager.GetByID(id);
            return View(result);
        }


        [HttpPost]
        public ActionResult UpdateHeadingForWriter(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var result = headingManager.GetByID(id);
            if (result.HeadStatus == true)
            {
                result.HeadStatus = false;
            }
            else
            {
                result.HeadStatus = true;
            }
            headingManager.HeadingDelete(result);
            return RedirectToAction("MyHeading");
        }


        public ActionResult AllMyHeadings(int page = 1)//SAYFALAMA İŞLEMİ KAÇTAN BAŞLASIN.
        {
            var headings = headingManager.fetchHeadingList().ToPagedList(page, 10);
            return View(headings);
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}