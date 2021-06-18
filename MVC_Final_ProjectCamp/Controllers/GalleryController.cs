using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Final_ProjectCamp.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ifm = new ImageFileManager(new EFImageFileDal());
        public ActionResult Index()
        {
            var imageFiles = ifm.fetchImageList();
            return View(imageFiles);
        }
    }
}