using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndCoffeeInfo.UtilitiesLibrary {

	/// <summary>
	/// Provides various extension methods for Lists
	/// </summary> 
	public static class ListExtensions {

		/// <summary>
		/// Returns the original sequence or a new, empty list.
		/// </summary>
		public static IList<T> ToEmptyIfNull<T>(this IList<T> p_list) {
			return (p_list == null)
				? new List<T>()
				: p_list;
		}
	}
}

#region Tests

namespace CodeAndCoffeeInfo.UtilitiesLibrary.Tests {

	using NUnit.Framework;

	[TestFixture]
	public class ListExtensions_ToEmptyIfNull_Tests {

		[Test]
		public void Returns_an_new_empty_list_when_list_is_null() {

			IList<string> original = null;

			IList<string> result = original.ToEmptyIfNull();

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Empty);
		}

		[Test]
		public void Returns_the_original_unaltered_list_when_list_is_not_null() {

			IList<string> original = new List<string> {
				"Item1",
				"Item2",
				"Item3"
			};

			IList<string> result = original.ToEmptyIfNull();

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Not.Empty);
			Assert.That(result, Is.EqualTo(original));
		}

	}
}

#endregion
