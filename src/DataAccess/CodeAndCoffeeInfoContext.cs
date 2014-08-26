using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndCoffeeInfo.DataAccess {

	public class CodeAndCoffeeInfoContext : DbContext {

		public CodeAndCoffeeInfoContext() : base("CCI") {
			
		}
	}
}
