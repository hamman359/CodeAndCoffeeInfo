using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeAndCoffeeInfo.Core.Model;
using CodeAndCoffeeInfo.UtilitiesLibrary;

namespace CodeAndCoffeeInfo.DataAccess.Mappings {

	public class CCSessionMap : ModelBaseMap<CCSession> {

		public CCSessionMap() {

			this.ToTable("CCSession");

			this.Property(x => x.Name)
				.HasColumnType(DBDataTypes.NVARCHAR)
				.HasMaxLength(100)
				.IsRequired();

			this.Property(x => x.Description)
				.HasColumnType(DBDataTypes.NVARCHAR)
				.IsOptional();

		}
	}
}
