using System.Web.Mvc;

namespace CodeAndCoffeeInfo.Web.Areas.SysAdmin
{
    public class SysAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SysAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SysAdmin_default",
                "SysAdmin/{controller}/{action}/{id}",
				new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				new[] { "CodeAndCoffeeInfo.Web.Areas.SysAdmin.Controllers" }
            );
        }
    }
}