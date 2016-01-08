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
    public class GuestbookController : Controller
    {
        // GET: Admin/Guestbook
        public ActionResult Index(int pageNo = 1, int pageSize = 10)
        {
            IGuestbookDAC dac = new GuestbookDAC();
            int totalNoRecords;
            int startIndex = pageSize * (pageNo - 1);
            IList<Guestbook> guestbooks = dac.Get(null, "DateCreated DESC", startIndex, pageSize, out totalNoRecords);
            return View(guestbooks);
        }

        public ActionResult Edit(int id)
        {
            IGuestbookDAC dac = new GuestbookDAC();
            var guestbook = dac.Get(id);
            var model = new GuestbookEdit { Comment=guestbook.Comment,Date=guestbook.DateCreated,Display=guestbook.Display,GuestbookID=guestbook.GuestbookID,Name=guestbook.Name,Reply=guestbook.Reply };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(GuestbookEdit guestbook)
        {
            if (!ModelState.IsValid)
                return View(guestbook);
            IGuestbookDAC dac = new GuestbookDAC();
            dac.Update(guestbook.GuestbookID,guestbook.Display);
            dac.Update(guestbook.GuestbookID, guestbook.Reply);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IGuestbookDAC dac = new GuestbookDAC();
            dac.Delete(id);
            return RedirectToAction("Index");
        }
    }
}