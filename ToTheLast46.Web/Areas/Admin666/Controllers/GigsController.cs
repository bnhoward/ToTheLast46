using Nightjar.ToTheLast.DAL;
using Nightjar.ToTheLast.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToTheLast46.Web.Areas.Admin.Controllers
{
    public class GigsController : Controller
    {
        // GET: Admin/Gigs
        public ActionResult Index()
        {
            IGigDAC dac = new GigDAC();
            int totalNoRecords;

            //upcoming gigs
            int startIndex = 0;
            IList<Gig> upcomingGigs = dac.Get("StartDateTime>=DATE()", "StartDateTime ASC", startIndex, Int32.MaxValue, out totalNoRecords);
            return View(upcomingGigs);
        }
    }
}