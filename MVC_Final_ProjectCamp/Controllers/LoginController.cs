using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using MVC_Final_ProjectCamp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class LoginController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EFAdminDal()), new WriterManager(new EFWriterDal()));
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto lgdto)
        {
            if (authService.Login(lgdto))
            {
                FormsAuthentication.SetAuthCookie(lgdto.AdminUsername, false);
                Session["AdminUsername"] = lgdto.AdminUsername;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }
            //Context c = new Context();
            //var adminUserInf = c.Admins.FirstOrDefault(x => x.AdminUsername == ad.AdminUsername && x.AdminPassword == ad.AdminPassword);//Geriye sadece bir admin döndürür
            //if (adminUserInf !=null)
            //{
            //    FormsAuthentication.SetAuthCookie(adminUserInf.AdminUsername,false);//auth yetkilendirme cookie alma ve kalıcılık
            //    Session["AdminUsername"] = adminUserInf.AdminUsername;
            //    return RedirectToAction("Index", "AdminCategory");
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}

        }
        [HttpGet]
        public ActionResult ForAdminRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForAdminRegister(LoginDto loginDto)
        {
            authService.Register(loginDto.AdminUsername,loginDto.AdminPassword);
            return RedirectToAction("Index","AdminCategory");
        }
        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult WriterLogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(WriterDto writerLoginDto)
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6LePpV4bAAAAAFqD4a22ld2SmH4hE8_Sb2SAfm6R";
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResult>(reply);

            if (authService.WriterLogin(writerLoginDto) && captchaResponse.Success)
            {
                FormsAuthentication.SetAuthCookie(writerLoginDto.WriterMail, false);
                Session["WriterMail"] = writerLoginDto.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return RedirectToAction("WriterLogin");
            }

        }
    }
}