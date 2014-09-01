using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CodeAndCoffeeInfo.Core.Model;
using CodeAndCoffeeInfo.DataAccess.Queries;

using Highway.Data;

namespace CodeAndCoffeeInfo.Web.Controllers {

	public class HomeController : CCIControllerBase {

		public HomeController(IRepository repo) : base(repo) {
			
		}

		public ActionResult Index() {

			var sessions = m_repo.Find(new GetAllCCSessions()).ToList();
			//var sessions = m_repo.Find(Queries.FindAll<CCSession>()).ToList();


			ViewBag.CCSessions = sessions;

			return View();
		}

		public ActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact() {
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}