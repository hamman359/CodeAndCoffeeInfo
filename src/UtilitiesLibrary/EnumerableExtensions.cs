using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndCoffeeInfo.UtilitiesLibrary {

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