using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndCoffeeInfo.UtilitiesLibrary {

	/// <summary>
	/// Provides constants that represent available Data Types in the database.
	/// Used to eliminate "Magic String" values in DB Mapping files.
	/// </summary>
	public static class DBDataTypes {

		public const string BIT = "bit";
		public const string CHAR = "char";
		public const string DATE = "date";
		public const string DATETIME = "datetime";
		public const string DECIMAL = "decimal";
		public const string FLOAT = "float";
		public const string INT = "int";
		public const string MONEY = "money";
		public const string NCHAR = "nchar";
		public const string NUMERIC = "numeric";
		public const string NVARCHAR = "nvarchar";
		public const string TEXT = "text";
		public const string TIME = "time";
		public const string TIMESTAMP = "timestamp";
		public const string VARCHAR = "varchar";
	}
}
