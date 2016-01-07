using System.Web.Mvc;

namespace ToTheLast46.Web.Areas.Admin
{
    public class Admin666AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin666";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin666_default",
                "Admin666/{controller}/{action}/{id}",
                new { controller = "Content", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}