using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndCoffeeInfo.UtilitiesLibrary {

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
