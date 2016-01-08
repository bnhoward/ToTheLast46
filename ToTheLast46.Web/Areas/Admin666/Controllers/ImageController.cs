using Nightjar.ToTheLast.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToTheLast46.Web.Areas.Admin666.Models;

namespace ToTheLast46.Web.Areas.Admin666.Controllers
{
    public class ImageController : Controller
    {
        // GET: Admin666/Image
        public ActionResult Index(int galleryID)
        {
            IImageDAC dac = new ImageDAC();
            IGalleryDAC galleryDAC = new GalleryDAC();
            var gallery = galleryDAC.GetGallery(galleryID);
            ViewBag.Gallery = gallery.Name;
            ViewBag.GalleryID = gallery.GalleryID;
            var images = dac.Get(galleryID);
            return View(images);
        }

        public ActionResult Create(int galleryID)
        {
            var model = new ImageCreate { GalleryID = galleryID };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, ImageCreate image)
        {
            if (file == null)
                ModelState.AddModelError("Filename", "Please select an image");
            else
                image.Filename = file.FileName;

            if (!ModelState.IsValid)
                return View(image);

            string path = System.IO.Path.Combine(Server.MapPath("~/SiteContent/Images/Gallery/"), image.Filename);
            file.SaveAs(path);

            IImageDAC dac = new ImageDAC();
            dac.Add(image.Filename, image.Title, image.GalleryID, 1);
            return RedirectToAction("Index", new { galleryID = image.GalleryID });
        }

        public ActionResult Edit(int id)
        {
            IImageDAC dac = new ImageDAC();
            var image = dac.GetImage(id);
            var model = new ImageEdit { Filename = image.Filename, GalleryID = image.GalleryID, Title = image.Title, ImageID = image.ImageID };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ImageEdit image)
        {
            if (!ModelState.IsValid)
                return View(image);
            IImageDAC dac = new ImageDAC();
            dac.Update(image.ImageID, image.Title, 1);
            return RedirectToAction("Index", new { galleryID = image.GalleryID });
        }

        [HttpPost]
        public ActionResult Delete(int id, int galleryID)
        {
            IImageDAC dac = new ImageDAC();
            dac.Delete(id);
            return RedirectToAction("Index", new { galleryID = galleryID });
        }
    }
}