using Business.Concrete;
using Business.ValidationRules_FV;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator cv=new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.fetchContactList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var getContactValues = cm.GetByID(id);
            return View(getContactValues);
        }
        public PartialViewResult ContactSideMenu()
        {
            return PartialView();
        }
    }
}