using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToTheLast46.Web.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Homepage");
        }

        // GET: Admin/Content
        public ActionResult Homepage()
        {
            ViewBag.Content=System.IO.File.ReadAllText(Server.MapPath(@"~\App_Data\default.aspx.htm"));
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Homepage(string content)
        {
            using (var writer = new System.IO.StreamWriter(Server.MapPath(@"~\App_Data\default.aspx.htm")))
            {
                writer.Write(content);
            }
            TempData["Success"] = true;
            return RedirectToAction("Homepage");
        }
    }
}