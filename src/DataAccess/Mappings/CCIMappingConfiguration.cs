using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Highway.Data;


namespace CodeAndCoffeeInfo.DataAccess.Mappings {

	public class CCIMappingConfiguration : IMappingConfiguration {
		
		public void ConfigureModelBuilder(DbModelBuilder modelBuilder) {

			modelBuilder.Configurations.Add(new CCSessionMap());
			// Register mappings here
			// i.e.
			// modelBuilder.Configurations.Add(new ItemMap());
		}
	}
}
