using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeAndCoffeeInfo.Web.Areas.SysAdmin.Models;

namespace CodeAndCoffeeInfo.Web.Areas.SysAdmin.Controllers
{
	public partial class HtmlTagsController : Controller
    {
        // GET: SysAdmin/HtmlTags
		public virtual ActionResult Index()
		{
			var model = new TagsTest(); //TODO: Populate this object with test data.

			return View(MVC.SysAdmin.HtmlTags.Views.Index, model);
        }
    }
}