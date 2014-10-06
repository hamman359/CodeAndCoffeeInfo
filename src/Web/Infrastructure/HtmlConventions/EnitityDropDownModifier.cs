using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CodeAndCoffeeInfo.Core.Model;
using CodeAndCoffeeInfo.DataAccess;
using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Elements;
using HtmlTags;

namespace CodeAndCoffeeInfo.UtilitiesLibrary.HtmlTags {

	public class EnitityDropDownModifier : IElementModifier {

		public bool Matches(ElementRequest token) {
			return typeof(ModelBase).IsAssignableFrom(token.Accessor.PropertyType);
		}

		public void Modify(ElementRequest request) {
			request.CurrentTag.RemoveAttr("type");
			request.CurrentTag.TagName("select");
			request.CurrentTag.Append(new HtmlTag("option"));

			var context = request.Get<CCIContext>();
			var entities = context.Set(request.Accessor.PropertyType)
				.Cast<ModelBase>()
				.ToList();
			var value = request.Value<ModelBase>();

			foreach(var entity in entities) {
				var optionTag = new HtmlTag("option")
					.Value(entity.Id.ToString())
					.Text(entity.DisplayValue);

				if(value != null && value.Id == entity.Id)
					optionTag.Attr("selected");

				request.CurrentTag.Append(optionTag);
			}
		}
	}
}
