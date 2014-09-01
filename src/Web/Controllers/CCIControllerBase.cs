using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Highway.Data;

namespace CodeAndCoffeeInfo.Web.Controllers {

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1012:AbstractTypesShouldNotHaveConstructors")]
	public abstract class CCIControllerBase : Controller {

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
		protected readonly IRepository m_repo;

		public CCIControllerBase(IRepository repo) {
			m_repo = repo;
		}
	}
}
