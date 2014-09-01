using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAndCoffeeInfo.Core.Model;
using CodeAndCoffeeInfo.UtilitiesLibrary;

namespace CodeAndCoffeeInfo.TestLibrary {

	/// <summary>
	/// Many object builders and data helpers need to create objects, and those objects need to
	/// have IDs. This is basically a global autonumber and helps ensure that a unique value is assigned 
	/// to each object that is created in test setup.
	/// 
	/// This will get reinitialized each time the app domain is reloaded, which happens frequently 
	/// during test cycles.
	/// 
	/// We count down from Int32.Max as a poor man's way of avoiding ID collisions with "real" IDs that
	/// may already exist in the database.
	/// </summary>
	public static class IdSequencer {

		private static int NEXT_VALUE = Int32.MaxValue;

		public static int Next() {
			return NEXT_VALUE--;
		}


		/// <summary>
		/// Given an ID, returns TRUE if it is a value that was issued by this sequencer or FALSE otherwise.
		/// </summary>
		public static bool WasIssuedBySequencer(int p_id) {

			// We use a decrementing sequence, so we assume any ID greater than the next value to hand out 
			// was previously issued from that sequence
			return p_id > NEXT_VALUE;
		}
	}

	public static class IdSequencerExtensions {

		/// <summary>
		/// Returns TRUE if the ID was issued by the IdSequencer.
		/// 
		/// This is basically a syntactic sugar over <see cref="IdSequencer.WasIssuedBySequencer"/>
		/// </summary>
		public static bool WasIssuedByIdSequencer(this int p_id) {
			return IdSequencer.WasIssuedBySequencer(p_id);
		}
	}
}
