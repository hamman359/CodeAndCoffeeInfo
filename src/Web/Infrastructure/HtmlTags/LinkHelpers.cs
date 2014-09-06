using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HtmlTags;
using Microsoft.Web.Mvc;

namespace CodeAndCoffeeInfo.Web.Infrastructure.HtmlTags {

	public static class LinkHelpers {

		public static HtmlTag Link<TController>(
			this HtmlHelper helper,
			Expression<Action<TController>> action,
			string linkText)
			where TController : Controller {
			
			var url = LinkBuilder.BuildUrlFromExpression(
						  helper.ViewContext.RequestContext,
						  RouteTable.Routes, action);

			return new HtmlTag("a", t => {
				t.Text(linkText);
				t.Attr("href", url);
			});
		}

		public static HtmlTag ButtonLink<TController>(
			this HtmlHelper helper,
			Expression<Action<TController>> action,
			string linkText)
			where TController : Controller {

			return helper.Link(action, linkText).AddClass("btn");
		}
	}
}