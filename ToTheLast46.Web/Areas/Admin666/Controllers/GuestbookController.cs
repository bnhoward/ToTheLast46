using Nightjar.ToTheLast.DAL;
using Nightjar.ToTheLast.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            IList<Guestbook> guestbooks = dac.Get("Display=Yes", "DateCreated DESC", startIndex, pageSize, out totalNoRecords);
            return View(guestbooks);
        }
    }
}