using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAndCoffeeInfo.Web.Areas.SysAdmin.Controllers
{
	public partial class HtmlTagsController : Controller
    {
        // GET: SysAdmin/HtmlTags
		public virtual ActionResult Index()
        {
            return View();
        }
    }
}