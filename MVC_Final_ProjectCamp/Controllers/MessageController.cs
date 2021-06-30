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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mem = new MessageManager(new EFMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messageList = mem.fetchMessageListInbox();
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var messageList = mem.fetchMessageListSendbox();
            return View(messageList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            ValidationResult result = messageValidator.Validate(m);
            if (result.IsValid)
            {
                m.MessageDate =DateTime.Parse( DateTime.Now.ToShortDateString());
                mem.MessageAddBL(m);
                return RedirectToAction("Sendbox");
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
        public ActionResult GetInboxMessageDetails(int id)
        {
            var getValues = mem.GetByID(id);
            return View(getValues);
        }
        public ActionResult GetMessageDetails(int id)
        {
            var result = mem.GetByID(id);
            return View(result);
        }
        public ActionResult Draft()
        {
            var result = mem.IsDraft();
            return View(result);
        }

        public ActionResult GetDraftDetails(int id)
        {
            var result = mem.GetByID(id);
            return View(result);
        }

        public ActionResult IsRead(int id)
        {
            var result = mem.GetByID(id);
            if (result.IsRead == false)
            {
                result.IsRead = true;
            }
            else
            {
                result.IsRead = false;
            }
            mem.MessageUpdate(result);
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageRead()
        {
            var result = mem.fetchMessageListInbox().Where(m => m.IsRead == true).ToList();
            return View(result);
        }

        public ActionResult MessageUnRead()
        {
            var result = mem.GetAllRead();
            return View(result);
        }
    }
}