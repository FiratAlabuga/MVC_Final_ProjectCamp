using Business.Concrete;
using Business.ValidationRules_FV;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FetchCategoryList()
        {
            var categoryValues = cm.fetchCategoryList();
            return View(categoryValues);
        }
        //sayfa yüklendiğinden çalışacak
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        //Http post için çalışacak
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryAddBL(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            //validasyon kontrolü categoryvalidator sınıfındaki olan değerlere göre doğruluk kontrolü
            ValidationResult validationResult = categoryValidator.Validate(p);
            if (validationResult.IsValid)//doğrulanmış ise 
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("FetchCategoryList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}