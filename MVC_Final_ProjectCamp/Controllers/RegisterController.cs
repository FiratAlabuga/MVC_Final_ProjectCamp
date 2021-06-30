using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        IAuthService authService = new AuthManager(new AdminManager(new EFAdminDal()), new WriterManager(new EFWriterDal()));
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {
            authService.Register(loginDto.AdminUsername, loginDto.AdminPassword);
            return RedirectToAction("Index", "AdminCategory");
        }

        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterRegister(WriterDto writerLoginDto)
        {
            authService.WriterRegister(writerLoginDto.WriterMail, writerLoginDto.WriterPassword);
            return RedirectToAction("MyContent", "WriterPanelContent");
        }
    }
}