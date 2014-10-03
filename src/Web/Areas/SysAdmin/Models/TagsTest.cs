using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NodaTime;

namespace CodeAndCoffeeInfo.Web.Areas.SysAdmin.Models
{
	public class TagsTest
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public bool RememberMe { get; set; }
		public string Phone { get; set; }
		public string Url { get; set; }
		public TestEnum EnumValue { get; set; }
		public Color Color { get; set; }
		public DateTime StartDate { get; set; }
		public LocalDate LocalDate { get; set; }
		public LocalTime LocalTime { get; set; }
		public LocalDateTime LocalDateTime { get; set; }
		public OffsetDateTime OffsetDateTime { get; set; }
		public Guid Guid { get; set; }
		public decimal Decimal { get; set; }
		public int Integer { get; set; }
		public float Float { get; set; }
		public double Double { get; set; }
	}
}

