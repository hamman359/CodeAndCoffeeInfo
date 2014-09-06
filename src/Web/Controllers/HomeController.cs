﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeAndCoffeeInfo.Core.Model;
using CodeAndCoffeeInfo.DataAccess.Queries;
using CodeAndCoffeeInfo.Web.Infrastructure;
using Highway.Data;

namespace CodeAndCoffeeInfo.Web.Controllers {

	public partial class HomeController : CCIControllerBase {

		public HomeController(IRepository repo, IWebConfig config) : base(repo, config) {
			
		}

		public virtual ActionResult Index() {

			var sessions = m_repo.Find(new GetAllCCSessions()).ToList();

			ViewBag.CCSessions = sessions;

			return View();
		}

		public virtual ActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public virtual ActionResult Contact() {
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}