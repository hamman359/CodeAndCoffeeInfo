using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeAndCoffeeInfo.Core.Model;
using CodeAndCoffeeInfo.DataAccess.Queries;
using CodeAndCoffeeInfo.TestLibrary;
using CodeAndCoffeeInfo.TestLibrary.DataHelpers;
using Highway.Data.Contexts;
using NUnit.Framework;

namespace CodeAnCofeeInfo.DataAccess.Queries.Tests {

	[TestFixture]
	public class GetAllCCSessions_Tests : InMemoryDataTestBase {

		[Test]
		public void Returns_All_CCSession_Records() {

			m_context.Add(CCSessionHelper.Create());
			m_context.Add(CCSessionHelper.Create());

			m_context.Commit();

			var query = new GetAllCCSessions();

			var results = query.Execute(m_context);

			Assert.That(results.Count(), Is.EqualTo(2));
		}
	}
}
