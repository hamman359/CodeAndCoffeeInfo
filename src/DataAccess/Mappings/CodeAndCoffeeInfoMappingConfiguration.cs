using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Highway.Data;


namespace CodeAndCoffeeInfo.DataAccess.Mappings {

	public class CodeAndCoffeeInfoMappingConfiguration : IMappingConfiguration {
		
		public void ConfigureModelBuilder(DbModelBuilder modelBuilder) {

			// Register mappings here
			// i.e.
			// modelBuilder.Configurations.Add(new ItemMap());
		}
	}
}
