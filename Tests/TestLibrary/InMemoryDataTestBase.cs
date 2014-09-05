using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Highway.Data;
using Highway.Data.Contexts;

using NUnit.Framework;

namespace CodeAndCoffeeInfo.TestLibrary {

	/// <summary>
	/// Base class to be used by Tests that need to write to or read from a database.
	/// Provides an InMemoryDataContext that allows for fast and simple tests against a
	/// real data store. Also disposes of the InMemoryDataContext.
	/// </summary>
	public abstract class InMemoryDataTestBase {

		protected IDataContext m_context;

		[SetUp]
		public void Setup() {

			m_context = new InMemoryDataContext();
		}

		[TearDown]
		public void TearDown() {

			m_context.Dispose();
		}
	}
}
