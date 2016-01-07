using Nightjar.ToTheLast.DAL;
using Nightjar.ToTheLast.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToTheLast46.Web.Areas.Admin.Controllers
{
    public class ProfilesController : Controller
    {
        // GET: Admin/Profiles
        public ActionResult Index()
        {
            IProfileDAC dac = new ProfileDAC();
            IList<Profile> profiles = dac.GetAll();
            return View(profiles);
        }
    }
}