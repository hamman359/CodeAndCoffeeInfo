using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NodaTime;

namespace CodeAndCoffeeInfo.Web.Areas.SysAdmin.Controllers
{
	public partial class HomeController : Controller
    {
        // GET: SysAdmin/Home
		public virtual ActionResult Index()
        {
            return View(MVC.SysAdmin.Home.Views.Index);
        }
    }
}