﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAndCoffeeInfo.Core.Model;
using CodeAndCoffeeInfo.UtilitiesLibrary;
using Highway.Data;

namespace CodeAndCoffeeInfo.TestLibrary.DataHelpers {

	/// <summary>
	/// Provides DataHelper methods for creating test data for CCSession objects.
	/// </summary>
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

		public static void Save(IDataContext p_context, CCSession p_ccSession) {

			// When saving a CCSession to a DataConxtext, we want to let the DB generate the ID
			// Therefore, if the ID currently associated with the object was generated by the 
			// IdSequenser, then we need to reset it to the default value so that the DB can assign it.
			if(p_ccSession.Id.WasIssuedByIdSequencer()) {
				p_ccSession.Id = default(int);
			}

			p_context.Add(p_ccSession);
			p_context.Commit();
		}

		public static void Save(IDataContext p_context, params CCSession[] p_ccSessions) {

			foreach(var item in p_ccSessions.ToEmptyIfNull()) {
				Save(p_context, item);
			}
		}

		public static CCSession[] CreateMultiple(int p_numSessions) {

			var sessions = new List<CCSession>();

			for(int i = 0; i < p_numSessions; i++) {
				sessions.Add(Create());
			}

			return sessions.ToArray();
		}

	}

}
