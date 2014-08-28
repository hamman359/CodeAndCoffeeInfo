using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeAndCoffeeInfo.Core.Model;

namespace CodeAndCoffeeInfo.DataAccess.Mappings {

	public class CCSessionMap : ModelBaseMap<CCSession> {

		public CCSessionMap() {

			this.ToTable("CCSession");

			this.Property(x => x.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired();

			this.Property(x => x.Description)
				.HasColumnType("nvarchar")
				.IsOptional();

		}
	}
}
