using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeAndCoffeeInfo.Web.Infrastructure;
using Highway.Data;

namespace CodeAndCoffeeInfo.Web.Controllers {

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1012:AbstractTypesShouldNotHaveConstructors")]
	public abstract class CCIControllerBase : Controller {

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
		protected readonly IWebConfig m_config;
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
		protected readonly IRepository m_repo;

		/// <summary>
		/// This ctor should not be used. It exists only to keep Visual Studio happy
		/// </summary>
		public CCIControllerBase() {
			m_repo = null;
		}

		public CCIControllerBase(IRepository repo, IWebConfig config) {
			m_config = config;
			m_repo = repo;
		}
	}
}
