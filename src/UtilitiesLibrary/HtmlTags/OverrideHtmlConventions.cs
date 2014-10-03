using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FubuMVC.Core.UI;

namespace CodeAndCoffeeInfo.UtilitiesLibrary.HtmlTags {

	public class OverrideHtmlConventions : DefaultHtmlConventions {

		public OverrideHtmlConventions() : base() {

			Editors.Always.AddClass("form-control");

			Labels.Always.AddClass("control-label");
			Labels.Always.AddClass("col-md-2");
		}
	}
}
