using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndCoffeeInfo.DataAccess {

	public class CCIContext : DbContext {

		public CCIContext() : base("CCI") {
			
		}

		// Add DbSets for Root objects here
		// i.e. 
		// public DbSet<Item> Items { get; set; }
	}
}
