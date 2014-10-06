using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeAndCoffeeInfo.Core.Model {

	public abstract class ModelBase {

		public int Id { get; set; }

		public DateTime CreatedOn { get; set; }
		public string CreatedBy { get; set; }
		public DateTime UpdatedOn { get; set; }
		public string UpdatedBy { get; set; }

		public abstract string DisplayValue { get; }
	}
}
