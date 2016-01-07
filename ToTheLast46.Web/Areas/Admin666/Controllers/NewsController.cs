using Nightjar.ToTheLast.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToTheLast46.Web.Areas.Admin.Controllers
{
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
    }
}