// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591
#nullable enable

namespace Persistence.Entity
{
	[Table("schemaversions")]
	public class Schemaversion
	{
		[Column("schemaversionsid", IsPrimaryKey = true , IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public int      Schemaversionsid { get; set; } // integer
		[Column("scriptname"      , CanBeNull    = false                                                             )] public string   Scriptname       { get; set; } = null!; // character varying(255)
		[Column("applied"                                                                                            )] public DateTime Applied          { get; set; } // timestamp (6) without time zone
	}
}
