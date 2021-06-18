using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Concrete;
using System.Web.Mvc;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Business.ValidationRules_FV;
using FluentValidation.Results;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        // GET: Writer
        public ActionResult Index()
        {
            var writerValues = wm.fetchWriterList();
            return View(writerValues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterAddBL(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Update_Edit_Writer(int id)
        {
            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult Update_Edit_Writer(Writer w)
        {
            ValidationResult result = writerValidator.Validate(w);
            if (result.IsValid)
            {
                wm.WriterUpdate(w);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}