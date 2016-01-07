﻿using Nightjar.ToTheLast.DAL;
using Nightjar.ToTheLast.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToTheLast46.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Content= System.IO.File.ReadAllText(Server.MapPath(@"~\App_Data\default.aspx.htm"));
            return View();
        }

        public ActionResult Band()
        {
            IProfileDAC dac = new ProfileDAC();
            IList<Profile> profiles = dac.GetAll();
            return View(profiles);
        }

        public ActionResult Blog(int pageNo=1,int pageSize=6)
        {
            INewsDAC dac = new NewsDAC();
            int totalNoRecords;
            int startIndex = pageSize * (pageNo - 1);
            var news = dac.Get(null, "DateCreated DESC", startIndex, pageSize, out totalNoRecords);
            return View(news);
        }

        public ActionResult Gigs()
        {
            IGigDAC dac = new GigDAC();
            int totalNoRecords;

            //upcoming gigs
            int startIndex = 0;
            IList<Gig> upcomingGigs = dac.Get("StartDateTime>=DATE()", "StartDateTime ASC", startIndex, Int32.MaxValue, out totalNoRecords);
            return View(upcomingGigs);
        }

        public ActionResult Guestbook(int pageNo = 1, int pageSize = 10)
        {
            IGuestbookDAC dac = new GuestbookDAC();
            int totalNoRecords;
            int startIndex = pageSize * (pageNo - 1);
            IList<Guestbook> guestbooks = dac.Get("Display=Yes", "DateCreated DESC", startIndex, pageSize, out totalNoRecords);
            return View(guestbooks);
        }

        public ActionResult Gallery()
        {
            IGalleryDAC dac = new GalleryDAC();
            IList<Gallery> galleries = dac.Get();
            return View(galleries);
        }

        public ActionResult Friends()
        {
            ILinkDAC dac = new LinkDAC();
            int totalNoRecords, startIndex = 0;
            IList<Link> links = dac.Get(null, "SortOrder ASC", startIndex, Int32.MaxValue, out totalNoRecords);
            return View(links);
        }
    }
}