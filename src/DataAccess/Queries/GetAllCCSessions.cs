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

namespace CodeAnCofeeInfo.DataAccess.Queries.Tests {

	using CodeAndCoffeeInfo.DataAccess.Queries;

	using Highway.Data.Contexts;

	using NUnit.Framework;

	[TestFixture]
	public class GetAllCCSessions_Tests {

		[Test]
		public void Returns_All_CCSession_Records() {
			var context = new InMemoryDataContext();

			context.Add(new CCSession() { Name = "Session 1" });
			context.Add(new CCSession() { Name = "Session 2" });

			context.Commit();

			var query = new GetAllCCSessions();

			var results = query.Execute(context);

			Assert.That(results.Count(), Is.EqualTo(2));
		}
	}
}