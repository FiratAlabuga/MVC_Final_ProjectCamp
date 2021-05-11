using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context c = new Context();
        public ActionResult Index()
        {
            //Toplam kategori sayısı
            var queryCategoryCount = c.Categories.Count().ToString();
            ViewBag.q1 = queryCategoryCount;
            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var querySoftwareTitleCount = c.Headings.Count(x => x.HeadName == "Yazılım").ToString();
            ViewBag.q2 = querySoftwareTitleCount;
            //Yazar adında 'a' harfi geçen yazar sayısı
            var query3 = (from x in c.Writers select x.WriterName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.q3 = query3;
            //En fazla başlığa sahip kategori adı
            var query4 = c.Categories.Where(u => u.CategoryID == c.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.q4 = query4;
            // Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var query5 = c.Categories.Count(x => x.CategoryStatus == true) - c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.q5 = query5;
            return View();
        }
    }
}