using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Highway.Data;
using Highway.Data.Contexts;
using NUnit.Framework;

namespace CodeAndCoffeeInfo.TestLibrary {


	public abstract class InMemoryDataTestBase {

		protected IDataContext m_context;

		[SetUp]
		public void Setup() {

			m_context = new InMemoryDataContext();
		}
	}
}
