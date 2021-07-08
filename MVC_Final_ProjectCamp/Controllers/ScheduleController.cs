using Business.Concrete;
using DataAccess.EntityFramework;
using MVC_Final_ProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class ScheduleController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        // GET: Schedule
        public ActionResult Index()
        {
            return View(new Schedule());
        }
        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new Schedule();
            var events = new List<Schedule>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var item in headingManager.fetchHeadingList())
            {
                events.Add(new Schedule()
                {
                    title = item.HeadName,
                    start = item.HeadDate,
                    end = item.HeadDate.AddDays(-14),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }


            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}