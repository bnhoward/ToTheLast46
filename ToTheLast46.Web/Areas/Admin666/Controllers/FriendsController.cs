using Nightjar.ToTheLast.DAL;
using Nightjar.ToTheLast.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToTheLast46.Web.Areas.Admin666.Models;

namespace ToTheLast46.Web.Areas.Admin.Controllers
{
    public class FriendsController : Controller
    {
        // GET: Admin/Friends
        public ActionResult Index()
        {
            ILinkDAC dac = new LinkDAC();
            int totalNoRecords, startIndex = 0;
            IList<Link> links = dac.Get(null, "SortOrder ASC", startIndex, Int32.MaxValue, out totalNoRecords);
            return View(links);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(LinkCreate link)
        {
            if (!ModelState.IsValid)
                return View(link);

            ILinkDAC dac = new LinkDAC();
            dac.Add(link.URL, link.Title, link.Note, link.SortOrder);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ILinkDAC dac = new LinkDAC();
            var link = dac.Get(id);
            var model = new LinkEdit { LinkID = link.LinkID, SortOrder = link.SortOrder, Note = link.Note, Title = link.Title, URL = link.URL };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(LinkEdit link)
        {
            if (!ModelState.IsValid)
                return View(link);
            ILinkDAC dac = new LinkDAC();
            dac.Update(link.LinkID, link.URL, link.Title, link.Note, link.SortOrder);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            ILinkDAC dac = new LinkDAC();
            dac.Delete(id);
            return RedirectToAction("Index");
        }
    }
}