using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAndCoffeeInfo.Core.Model;
using CodeAndCoffeeInfo.UtilitiesLibrary;

namespace CodeAndCoffeeInfo.TestLibrary.DataHelpers {

	public static class CCSessionHelper {

		public static CCSession Create(
			int? id = null,
			string name = null,
			string description = null,
			string createdBy = null,
			DateTime? createdOn = null,
			string updatedBy = null,
			DateTime? updatedOn = null) {

			if(createdBy.IsNullOrEmpty()) {
				createdBy = ShortGuid.NewGuid();
			}

			if(updatedBy.IsNullOrEmpty()) {
				updatedBy = createdBy;
			}

			var now = DateTime.Now;

			var ccSession = new CCSession {
				Id = id ?? IdSequencer.Next(),
				Name = name ?? ShortGuid.NewGuid(),
				Description = description ?? "Description " + ShortGuid.NewGuid(),
				CreatedBy = createdBy,
				CreatedOn = createdOn ?? now,
				UpdatedBy = updatedBy,
				UpdatedOn = createdOn ?? now
			};

			return ccSession;
		}

	}

}
