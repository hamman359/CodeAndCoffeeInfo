using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeAndCoffeeInfo.Core.Model {

	public class CCSession : ModelBase {

		public string Name { get; set; }
		public string Description { get; set; }

		public override string DisplayValue {
			get { return Name; }
		}
	}
}
