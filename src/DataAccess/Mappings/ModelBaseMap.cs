using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

using CodeAndCoffeeInfo.Core.Model;
using CodeAndCoffeeInfo.UtilitiesLibrary;

namespace CodeAndCoffeeInfo.DataAccess.Mappings {

	public class ModelBaseMap<T> : EntityTypeConfiguration<T> where T : ModelBase {


		public ModelBaseMap() {

			this.HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.Property(x => x.CreatedOn).HasColumnType(DBDataTypes.DATETIME).IsRequired();
			this.Property(x => x.CreatedBy).HasColumnType(DBDataTypes.NVARCHAR).IsRequired();
			this.Property(x => x.UpdatedOn).HasColumnType(DBDataTypes.DATETIME).IsRequired();
			this.Property(x => x.UpdatedBy).HasColumnType(DBDataTypes.NVARCHAR).IsRequired();
		}
	}
}
