using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAndCoffeeInfo.Web.Areas.SysAdmin.Controllers
{
	public partial class HomeController : Controller
    {
        // GET: SysAdmin/Home
		public virtual ActionResult Index()
        {
            return View();
        }
    }
}