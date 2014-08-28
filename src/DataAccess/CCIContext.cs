using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAndCoffeeInfo.Core.Model;

namespace CodeAndCoffeeInfo.DataAccess {

	public class CCIContext : DbContext {

		public CCIContext() : base("CCI") {
			
		}

		public DbSet<CCSession> CCSessions { get; set; }

		// Add DbSets for Root objects here
		// i.e. 
		// public DbSet<Item> Items { get; set; }
	}
}
