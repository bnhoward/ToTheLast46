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
    [Authorize]
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(GigCreate gig)
        {
            if (!ModelState.IsValid)
                return View(gig);

            IGigDAC dac = new GigDAC();
            dac.Add(gig.Description, gig.Venue, gig.Date);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            IGigDAC dac = new GigDAC();
            var gig = dac.Get(id);
            var model = new GigEdit { Date = gig.StartDateTime, Description = gig.Description, GigID = gig.GigID, Venue = gig.Venue };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(GigEdit gig)
        {
            if (!ModelState.IsValid)
                return View(gig);
            IGigDAC dac = new GigDAC();
            dac.Update(gig.GigID, gig.Description, gig.Venue, gig.Date);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IGigDAC dac = new GigDAC();
            dac.Delete(id);
            return RedirectToAction("Index");
        }
    }
}