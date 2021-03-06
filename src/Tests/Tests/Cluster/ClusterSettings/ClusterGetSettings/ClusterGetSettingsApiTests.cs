﻿using Elasticsearch.Net;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Framework;
using Tests.Framework.Integration;

namespace Tests.Cluster.ClusterSettings.ClusterGetSettings
{
	public class ClusterGetSettingsApiTests
		: ApiTestBase<ReadOnlyCluster, ClusterGetSettingsResponse, IClusterGetSettingsRequest, ClusterGetSettingsDescriptor,
			ClusterGetSettingsRequest>
	{
		public ClusterGetSettingsApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => "/_cluster/settings";

		protected override ClusterGetSettingsRequest Initializer { get; } = new ClusterGetSettingsRequest();

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.ClusterGetSettings(),
			(client, f) => client.ClusterGetSettingsAsync(),
			(client, r) => client.ClusterGetSettings(r),
			(client, r) => client.ClusterGetSettingsAsync(r)
		);
	}
}
