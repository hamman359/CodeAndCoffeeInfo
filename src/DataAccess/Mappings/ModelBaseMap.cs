using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using CodeAndCoffeeInfo.Core.Model;

namespace CodeAndCoffeeInfo.DataAccess.Mappings {

	public class ModelBaseMap<T> : EntityTypeConfiguration<T> where T : ModelBase {

		public ModelBaseMap() {

			this.HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.Property(x => x.CreatedOn).HasColumnType("datetime").IsRequired();
			this.Property(x => x.CreatedBy).HasColumnType("nvarchar").IsRequired();
			this.Property(x => x.UpdatedOn).HasColumnType("datetime").IsRequired();
			this.Property(x => x.UpdatedBy).HasColumnType("nvarchar").IsRequired();
		}
	}
}
