﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// This API will decrypt and re-read the entire keystore, on every cluster node, but only the reloadable secure settings will
		/// be applied.
		/// <para>Changes to other settings will not go into effect until the next restart. Once the call returns, the reload has been
		/// completed, meaning that all internal datastructures dependent on these settings have been changed. Everything should look as if
		/// the settings had the new value from the start.</para>
		/// <para>
		/// When changing multiple reloadable secure settings, modify all of them, on each cluster node, and then issue a reload_secure_settings call,
		/// instead of reloading after each modification.</para>
		/// </summary>
		IReloadSecureSettingsResponse ReloadSecureSettings(Func<ReloadSecureSettingsDescriptor, IReloadSecureSettingsRequest> selector = null);

		/// <inheritdoc cref="ReloadSecureSettings(System.Func{Nest.ReloadSecureSettingsDescriptor,Nest.IReloadSecureSettingsRequest})"/>
		IReloadSecureSettingsResponse ReloadSecureSettings(IReloadSecureSettingsRequest request);

		/// <inheritdoc cref="ReloadSecureSettings(System.Func{Nest.ReloadSecureSettingsDescriptor,Nest.IReloadSecureSettingsRequest})"/>
		Task<IReloadSecureSettingsResponse> ReloadSecureSettingsAsync(
			Func<ReloadSecureSettingsDescriptor, IReloadSecureSettingsRequest> selector = null,
			CancellationToken ct = default
		);

		/// <inheritdoc cref="ReloadSecureSettings(System.Func{Nest.ReloadSecureSettingsDescriptor,Nest.IReloadSecureSettingsRequest})"/>
		Task<IReloadSecureSettingsResponse> ReloadSecureSettingsAsync(IReloadSecureSettingsRequest request,
			CancellationToken ct = default
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="ReloadSecureSettings(System.Func{Nest.ReloadSecureSettingsDescriptor,Nest.IReloadSecureSettingsRequest})"/>
		public IReloadSecureSettingsResponse ReloadSecureSettings(
			Func<ReloadSecureSettingsDescriptor, IReloadSecureSettingsRequest> selector = null
		) =>
			ReloadSecureSettings(selector.InvokeOrDefault(new ReloadSecureSettingsDescriptor()));

		/// <inheritdoc cref="ReloadSecureSettings(System.Func{Nest.ReloadSecureSettingsDescriptor,Nest.IReloadSecureSettingsRequest})"/>
		public IReloadSecureSettingsResponse ReloadSecureSettings(IReloadSecureSettingsRequest request) =>
			DoRequest<IReloadSecureSettingsRequest, ReloadSecureSettingsResponse>(request, request.RequestParameters);

		/// <inheritdoc cref="ReloadSecureSettings(System.Func{Nest.ReloadSecureSettingsDescriptor,Nest.IReloadSecureSettingsRequest})"/>
		public Task<IReloadSecureSettingsResponse> ReloadSecureSettingsAsync(
			Func<ReloadSecureSettingsDescriptor, IReloadSecureSettingsRequest> selector = null,
			CancellationToken ct = default
		) =>
			ReloadSecureSettingsAsync(selector.InvokeOrDefault(new ReloadSecureSettingsDescriptor()), ct);

		/// <inheritdoc cref="ReloadSecureSettings(System.Func{Nest.ReloadSecureSettingsDescriptor,Nest.IReloadSecureSettingsRequest})"/>
		public Task<IReloadSecureSettingsResponse> ReloadSecureSettingsAsync(IReloadSecureSettingsRequest request, CancellationToken ct = default) =>
			DoRequestAsync<IReloadSecureSettingsRequest, IReloadSecureSettingsResponse, ReloadSecureSettingsResponse>(request, request.RequestParameters, ct);
	}
}
