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
		// GET: SysAdmin/HtmlTags/TagConventions
		public virtual ActionResult TagConventions()
		{
			var model = new TagsTest(); //TODO: Populate this object with test data.

			return View(MVC.SysAdmin.HtmlTags.Views.TagConventions, model);
        }

		// GET: SysAdmin/HtmlTags/Links
		public virtual ActionResult Links()
		{
			return View(MVC.SysAdmin.HtmlTags.Views.Links);
		}
    }
}