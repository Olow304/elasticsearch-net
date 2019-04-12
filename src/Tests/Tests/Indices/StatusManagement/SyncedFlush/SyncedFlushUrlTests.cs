﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;
using static Nest.Indices;

namespace Tests.Indices.StatusManagement.SyncedFlush
{
	public class SyncedFlushUrlTests
	{
		[U] public async Task Urls()
		{
			await POST($"/_flush/synced")
					.Request(c => c.SyncedFlush(new SyncedFlushRequest()))
					.RequestAsync(c => c.SyncedFlushAsync(new SyncedFlushRequest()))
				;
			
			await POST($"/_all/_flush/synced")
					.Fluent(c => c.SyncedFlush(All))
					.Request(c => c.SyncedFlush(new SyncedFlushRequest(All)))
					.FluentAsync(c => c.SyncedFlushAsync(All))
					.RequestAsync(c => c.SyncedFlushAsync(new SyncedFlushRequest(All)))
				;

			var index = "index1,index2";
			await POST($"/index1%2Cindex2/_flush/synced")
					.Fluent(c => c.SyncedFlush(index))
					.Request(c => c.SyncedFlush(new SyncedFlushRequest(index)))
					.FluentAsync(c => c.SyncedFlushAsync(index))
					.RequestAsync(c => c.SyncedFlushAsync(new SyncedFlushRequest(index)))
				;
		}
	}
}
