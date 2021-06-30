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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());

        public ActionResult Index()
        {
            var headingValues = hm.fetchHeadingList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            //o başlığa ait kategorinin listesi
            //valueMember=Seçmiş olduğum değerin id'si
            //displayMember=Seçmiş olduğum değerin görünüm kısmı=kendisi text
            List<SelectListItem> valueCategory = (from x in cm.fetchCategoryList() select new SelectListItem {Text=x.CategoryName,Value=x.CategoryID.ToString() }).ToList();
            //viewbag ile view'a  değerleri taşıma 
            ViewBag.vlc = valueCategory;
            List<SelectListItem> valueWriter = (from x in wm.fetchWriterList() select new SelectListItem { Text = x.WriterName+" "+x.WriterSurname, Value = x.WriterID.ToString() }).ToList();
            ViewBag.wlc = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading hp)
        {
            hp.HeadDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAddBL(hp);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.fetchCategoryList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valueCategory;
            var headValue = hm.GetByID(id);
            return View(headValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading h)
        {
            hm.HeadingUpdate(h);
            return RedirectToAction("Index");
        }
        public ActionResult ChangeStatusHeading(int id)
        {
            var headValue = hm.GetByID(id);
            if (headValue.HeadStatus == true)
            {
                headValue.HeadStatus = false;
            }
            else
            {
                headValue.HeadStatus = true;
            }
            hm.HeadingDelete(headValue);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeadingDeactive(int id)
        {
            var deactiveHeading = hm.GetByID(id);
            if (deactiveHeading.HeadStatus==true)
            {
                deactiveHeading.HeadStatus = false;
            }
            else
            {
                deactiveHeading.HeadStatus = true;
            }
            hm.HeadingDelete(deactiveHeading);
            return RedirectToAction("Index");
        }

    }
}