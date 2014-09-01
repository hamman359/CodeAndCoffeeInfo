using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeAndCoffeeInfo.Core.Model;

using Highway.Data;

namespace CodeAndCoffeeInfo.DataAccess.Queries {

	public class GetAllCCSessions : Query<CCSession> {

		public GetAllCCSessions() {

			ContextQuery = c => c.AsQueryable<CCSession>();
		}
	}
}
