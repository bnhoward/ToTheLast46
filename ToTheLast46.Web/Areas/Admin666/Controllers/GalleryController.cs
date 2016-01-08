using Nightjar.ToTheLast.DAL;
using Nightjar.ToTheLast.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToTheLast46.Web.Areas.Admin666.Models;

namespace ToTheLast46.Web.Areas.Admin666.Controllers
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(GalleryCreate gallery)
        {
            if (!ModelState.IsValid)
                return View(gallery);

            IGalleryDAC dac = new GalleryDAC();
            dac.Add(gallery.Name, gallery.Description, gallery.SortOrder);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            IGalleryDAC dac = new GalleryDAC();
            var gallery = dac.GetGallery(id);
            var model = new GalleryEdit { Description = gallery.Description, GalleryID = gallery.GalleryID, Name = gallery.Name, SortOrder = gallery.SortOrder, MainImage = gallery.DisplayImage };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(GalleryEdit gallery)
        {
            if (!ModelState.IsValid)
                return View(gallery);
            IGalleryDAC dac = new GalleryDAC();
            dac.Update(gallery.GalleryID, gallery.Name, gallery.Description, gallery.SortOrder, gallery.MainImage);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IGalleryDAC dac = new GalleryDAC();
            dac.Delete(id);
            return RedirectToAction("Index");
        }
    }
}