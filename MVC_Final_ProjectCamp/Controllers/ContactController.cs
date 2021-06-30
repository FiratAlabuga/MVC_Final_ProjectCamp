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
        MessageManager mem = new MessageManager(new EFMessageDal());
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
            var contact = cm.fetchContactList().Count();
            ViewBag.contact = contact;

            var sendMail = mem.fetchMessageListSendbox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mem.fetchMessageListInbox().Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = mem.fetchMessageListSendbox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var readMessage = mem.fetchMessageListInbox().Where(m => m.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = mem.GetAllRead().Count();
            ViewBag.unreadMessage = unreadMessage;
            return PartialView();
        }
    }
}