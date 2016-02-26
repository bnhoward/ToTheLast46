using Nightjar.ToTheLast.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToTheLast46.Web.Areas.Admin666.Models;

namespace ToTheLast46.Web.Areas.Admin666.Controllers
{
    //[Authorize]
    public class NewsController : Controller
    {
        // GET: Admin/News
        public ActionResult Index(int pageSize = 1000, int pageNo = 1)
        {
            INewsDAC dac = new NewsDAC();
            int totalNoRecords;
            int startIndex = pageSize * (pageNo - 1);
            var news = dac.Get(null, "DateCreated DESC", startIndex, pageSize, out totalNoRecords);
            return View(news);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NewsCreate news)
        {
            if (!ModelState.IsValid)
                return View(news);

            INewsDAC dac = new NewsDAC();
            dac.Add(news.Subject, news.NewsText);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            INewsDAC dac = new NewsDAC();
            var news = dac.Get(id);
            var model = new NewsEdit { DateCreated=news.DateCreated,NewsID=news.NewsID,NewsText=news.NewsText,Subject=news.Subject };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsEdit news)
        {
            if (!ModelState.IsValid)
                return View(news);
            INewsDAC dac = new NewsDAC();
            dac.Update(news.NewsID, news.Subject, news.NewsText);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            INewsDAC dac = new NewsDAC();
            dac.Delete(id);
            return RedirectToAction("Index");
        }
    }
}