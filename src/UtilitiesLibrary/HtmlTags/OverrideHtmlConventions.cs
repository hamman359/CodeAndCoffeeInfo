using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FubuCore.Reflection;
using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Elements;
using HtmlTags;
using NodaTime;

namespace CodeAndCoffeeInfo.UtilitiesLibrary.HtmlTags {

	public class OverrideHtmlConventions : DefaultHtmlConventions {

		public OverrideHtmlConventions() : base() {

			// All Form Fields
			Editors.Always.AddClass("form-control");

			// Labels
			Labels.Always.AddClass("control-label");
			Labels.Always.AddClass("col-md-2");
			Labels.ModifyForAttribute<DisplayAttribute>((t, a) => t.Text(a.Name));
			Labels.IfPropertyIs<bool>()
				.ModifyWith(er => er.CurrentTag.Text(er.OriginalTag.Text() + "?"));

			// Checkboxes
			Editors.IfPropertyIs<bool>().Attr("type", "checkbox");

			// Color
			Editors.IfPropertyIs<Color>().Attr("type", "color");

			// Dates & Times
			Editors.IfPropertyIs<DateTime>().Attr("type", "date");
			Editors.IfPropertyIs<LocalDate>().Attr("type", "date");
			Editors.IfPropertyIs<LocalTime>().Attr("type", "time");
			Editors.IfPropertyIs<LocalDateTime>().Attr("type", "datetime-local");
			Editors.IfPropertyIs<OffsetDateTime>().Attr("type", "datetime");

			// Email
			Editors.If(er => er.Accessor.Name.Contains("Email"))
				.Attr("type", "email");

			// Hidden
			Editors.IfPropertyIs<Guid>().Attr("type", "hidden");
			Editors.IfPropertyIs<Guid?>().Attr("type", "hidden");
			Editors.IfPropertyHasAttribute<HiddenInputAttribute>().Attr("type", "hidden");

			// Numbers
			Editors.IfPropertyIs<decimal?>().ModifyWith(m =>
				m.CurrentTag
				.Data("pattern", "9{1,9}.99")
				.Data("placeholder", "0.00"));
			Editors.IfPropertyIs<decimal>().ModifyWith(m =>
				m.CurrentTag
				.Data("pattern", "9{1,9}.99")
				.Data("placeholder", "0.00"));
			Editors.IfPropertyIs<int?>().ModifyWith(m =>
				m.CurrentTag
				.Data("pattern", "999")
				.Data("placeholder", "0"));
			Editors.IfPropertyIs<double?>().ModifyWith(m =>
				m.CurrentTag
				.Data("pattern", "9{1,9}.99")
				.Data("placeholder", "0.00"));
			Editors.IfPropertyIs<float?>().ModifyWith(m =>
				m.CurrentTag
				.Data("pattern", "9{1,9}.99")
				.Data("placeholder", "0.00"));

			// Password
			Editors.If(er => er.Accessor.Name.Contains("Password"))
				.Attr("type", "password");
			Editors
				.HasAttributeValue<DataTypeAttribute>(attr => attr.DataType == DataType.Password)
				.Attr("type", "password");

			// Radio Buttons
			Editors.Modifier<EnumDropDownModifier>();

			// Telephone
			Editors.If(er => er.Accessor.Name.Contains("Phone"))
				.Attr("type", "tel");
			Editors
				.HasAttributeValue<DataTypeAttribute>(attr => attr.DataType == DataType.PhoneNumber)
				.Attr("type", "tel");

			// URL
			Editors.If(er => er.Accessor.Name.Contains("Url"))
				.Attr("type", "url");
			Editors
				.HasAttributeValue<DataTypeAttribute>(attr => attr.DataType == DataType.Url)
				.Attr("type", "url");


		}
	}

	// Our modifier
	public class EnumDropDownModifier : IElementModifier {

		public bool Matches(ElementRequest token) {
			return token.Accessor.PropertyType.IsEnum;
		}

		public void Modify(ElementRequest request) {
			var enumType = request.Accessor.PropertyType;

			request.CurrentTag.RemoveAttr("type");
			request.CurrentTag.TagName("select");
			request.CurrentTag.Append(new HtmlTag("option"));

			foreach(var value in Enum.GetValues(enumType)) {

				var optionTag = new HtmlTag("option")
					.Value(value.ToString())
					.Text(Enum.GetName(enumType, value));
				request.CurrentTag.Append(
					optionTag);
			}
		}
	}

	public static class ElementCategoryExpressionExtensions {

		public static ElementActionExpression HasAttributeValue<TAttribute>(
			this ElementCategoryExpression expression,
			Func<TAttribute, bool> matches)
			where TAttribute : Attribute {

			return expression.If(er => {
				var attr = er.Accessor.GetAttribute<TAttribute>();
				return attr != null && matches(attr);
			});
		}
	}
}
