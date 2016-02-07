using Nightjar.ToTheLast.DAL;
using Nightjar.ToTheLast.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToTheLast46.Web.Areas.Admin666.Models;

namespace ToTheLast46.Web.Areas.Admin666.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        // GET: Admin/Profiles
        public ActionResult Index()
        {
            IProfileDAC dac = new ProfileDAC();
            IList<Profile> profiles = dac.GetAll();
            return View(profiles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProfileCreate profile)
        {
            if (!ModelState.IsValid)
                return View(profile);

            IProfileDAC dac = new ProfileDAC();
            dac.Add(profile.Name, profile.ProfileText, profile.SortOrder);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            IProfileDAC dac = new ProfileDAC();
            var profile = dac.GetProfile(id);
            var model = new ProfileEdit { ProfileID = profile.ProfileID, Name = profile.Name, ProfileText = profile.ProfileText, SortOrder = profile.SortOrder };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ProfileEdit profile)
        {
            if (!ModelState.IsValid)
                return View(profile);
            IProfileDAC dac = new ProfileDAC();
            dac.Update(profile.ProfileID, profile.Name, profile.ProfileText, profile.SortOrder);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            IProfileDAC dac = new ProfileDAC();
            dac.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult AddImage(HttpPostedFileBase file, int profileID)
        {
            if (file != null)
            {
                IProfileDAC dac = new ProfileDAC();
                var profile = dac.GetProfile(profileID);
                string path = System.IO.Path.Combine(Server.MapPath("~/SiteContent/Images/Band/"), profile.ImageName);
                file.SaveAs(path);
            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index");
        }
    }
}