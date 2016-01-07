using Nightjar.ToTheLast.DAL;
using Nightjar.ToTheLast.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}