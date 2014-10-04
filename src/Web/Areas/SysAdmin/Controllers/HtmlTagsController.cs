using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeAndCoffeeInfo.Web.Areas.SysAdmin.Models;
using NodaTime;

namespace CodeAndCoffeeInfo.Web.Areas.SysAdmin.Controllers
{
	public partial class HtmlTagsController : Controller
    {
		// GET: SysAdmin/HtmlTags/TagConventions
		public virtual ActionResult TagConventions() {

			LocalDateTime localDateTime = new LocalDateTime(2014, 1, 1, 7, 23, 47, 42);

			var model = new TagsTest {
				Name = "John Doe",
				Email = "John.Doe@email.com",
				Password = "Password1",
				ConfirmPassword = "Password1",
				RememberMe = true,
				Phone = "1234567890",
				Url = "http://google.com",
				EnumValue = TestEnum.Item2,
				Color = System.Drawing.Color.Green,
				StartDate = DateTime.Now,
				LocalDate = new LocalDate(2014, 1, 1),
				LocalDateTime = localDateTime,
				OffsetDateTime = new OffsetDateTime(localDateTime, Offset.FromHours(3)),
				Guid = Guid.NewGuid(),
				Decimal = 3.14m,
				Integer = 42,
				Float = 6.6666f,
				Double = 3.3333
			};

			return View(MVC.SysAdmin.HtmlTags.Views.TagConventions, model);
		}

		// GET: SysAdmin/HtmlTags/Links
		public virtual ActionResult Links()
		{
			return View(MVC.SysAdmin.HtmlTags.Views.Links);
		}
    }
}