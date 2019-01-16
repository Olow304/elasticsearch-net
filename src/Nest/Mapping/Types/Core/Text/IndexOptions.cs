﻿using System.Runtime.Serialization;


namespace Nest
{
	[StringEnum]
	public enum IndexOptions
	{
		[EnumMember(Value = "docs")]
		Docs,

		[EnumMember(Value = "freqs")]
		Freqs,

		[EnumMember(Value = "positions")]
		Positions,

		[EnumMember(Value = "offsets")]
		Offsets,
	}
}
