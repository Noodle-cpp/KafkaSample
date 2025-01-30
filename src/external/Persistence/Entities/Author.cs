// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591
#nullable enable

namespace DataModel
{
	[Table("Author")]
	public class Author
	{
		[Column("Id"         , CanBeNull = false, IsPrimaryKey = true)] public string    Id          { get; set; } = null!; // character varying
		[Column("FIO"                                                )] public string?   Fio         { get; set; } // character varying
		[Column("DateOfBirth"                                        )] public DateTime? DateOfBirth { get; set; } // timestamp (6) without time zone

		#region Associations
		/// <summary>
		/// AuthorToBook backreference
		/// </summary>
		[Association(ThisKey = nameof(Id), OtherKey = nameof(Book.AuthorId))]
		public IEnumerable<Book> Books { get; set; } = null!;
		#endregion
	}
}
