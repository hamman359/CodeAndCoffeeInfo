using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Highway.Data;

namespace CodeAndCoffeeInfo.Web.Controllers {

	public class CCIControllerBase : Controller {

		protected readonly IRepository m_repo;

		public CCIControllerBase(IRepository repo) {
			m_repo = repo;
		}
	}
}
