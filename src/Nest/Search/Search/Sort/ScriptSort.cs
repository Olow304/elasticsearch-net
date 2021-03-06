﻿using System;
using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	[ReadAs(typeof(ScriptSort))]
	[InterfaceDataContract]
	public interface IScriptSort : ISort
	{
		[DataMember(Name ="script")]
		IScript Script { get; set; }

		[DataMember(Name ="type")]
		string Type { get; set; }
	}

	public class ScriptSort : SortBase, IScriptSort
	{
		public string Language { get; set; }
		public IScript Script { get; set; }

		public string Type { get; set; }
		protected override Field SortKey => "_script";
	}

	public class ScriptSortDescriptor<T> : SortDescriptorBase<ScriptSortDescriptor<T>, IScriptSort, T>, IScriptSort
		where T : class
	{
		protected override Field SortKey => "_script";

		IScript IScriptSort.Script { get; set; }

		string IScriptSort.Type { get; set; }

		public virtual ScriptSortDescriptor<T> Type(string type) => Assign(type, (a, v) => a.Type = v);

		public ScriptSortDescriptor<T> Script(Func<ScriptDescriptor, IScript> scriptSelector) =>
			Assign(scriptSelector, (a, v) => a.Script = v?.Invoke(new ScriptDescriptor()));
	}
}
