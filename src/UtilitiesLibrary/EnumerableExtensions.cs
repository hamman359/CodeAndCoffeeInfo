using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndCoffeeInfo.UtilitiesLibrary {

	/// <summary>
	/// Provides various extension methods for Enumerables
	/// </summary> 
	public static class EnumerableExtensions {

		/// <summary>
		/// Returns the original sequence or a new, empty list.
		/// </summary>
		public static IEnumerable<T> ToEmptyIfNull<T>(this IEnumerable<T> p_sequence) {

			return (p_sequence == null)
				? new List<T>()
				: p_sequence;
		}
	}
}

#region Tests

namespace CodeAndCoffeeInfo.UtilitiesLibrary.Tests {

	using NUnit.Framework;

	[TestFixture]
	public class EnumerableExtensions_ToEmptyIfNull_Tests {

		[Test]
		public void Returns_an_new_empty_list_when_enumerable_is_null() {

			IEnumerable<string> original = null;

			IEnumerable<string> result = original.ToEmptyIfNull();

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Empty);
		}

		[Test]
		public void Returns_the_original_unaltered_IEnumerable_when_IEnumerable_is_not_null() {

			IEnumerable<string> original = new List<string> {
				"Item1",
				"Item2",
				"Item3"
			};

			IEnumerable<string> result = original.ToEmptyIfNull();

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Not.Empty);
			Assert.That(result, Is.EqualTo(original));
		}

	}
}

#endregion