﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// The bulk API makes it possible to perform many index/delete operations in a single API call.
		/// This can greatly increase the indexing speed.
		/// <para> </para>
		/// http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/docs-bulk.html
		/// </summary>
		/// <param name="request">A descriptor the describe the index/create/delete operation for this bulk operation</param>
		IBulkResponse Bulk(IBulkRequest request);

		/// <inheritdoc />
		IBulkResponse Bulk(Func<BulkDescriptor, IBulkRequest> selector);

		/// <inheritdoc />
		Task<IBulkResponse> BulkAsync(IBulkRequest request, CancellationToken ct = default);

		/// <inheritdoc />
		Task<IBulkResponse> BulkAsync(Func<BulkDescriptor, IBulkRequest> selector, CancellationToken ct = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IBulkResponse Bulk(IBulkRequest request) =>
			DoRequest<IBulkRequest, BulkResponse>(request, request.RequestParameters);

		/// <inheritdoc />
		public IBulkResponse Bulk(Func<BulkDescriptor, IBulkRequest> selector) =>
			Bulk(selector.InvokeOrDefault(new BulkDescriptor()));

		/// <inheritdoc />
		public Task<IBulkResponse> BulkAsync(IBulkRequest request, CancellationToken ct = default) =>
			DoRequestAsync<IBulkRequest, IBulkResponse, BulkResponse>(request, request.RequestParameters, ct);

		/// <inheritdoc />
		public Task<IBulkResponse> BulkAsync(Func<BulkDescriptor, IBulkRequest> selector, CancellationToken ct = default) =>
			BulkAsync(selector.InvokeOrDefault(new BulkDescriptor()), ct);
	}
}
