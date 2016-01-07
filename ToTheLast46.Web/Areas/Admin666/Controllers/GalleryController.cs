using Nightjar.ToTheLast.DAL;
using Nightjar.ToTheLast.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToTheLast46.Web.Areas.Admin.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Admin/Gallery
        public ActionResult Index()
        {
            IGalleryDAC dac = new GalleryDAC();
            IList<Gallery> galleries = dac.Get();
            return View(galleries);
        }
    }
}