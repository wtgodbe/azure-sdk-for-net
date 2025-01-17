// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.AppPlatform
{
    /// <summary>
    /// A class representing a collection of <see cref="SupportedBuildpackResource" /> and their operations.
    /// Each <see cref="SupportedBuildpackResource" /> in the collection will belong to the same instance of <see cref="AppBuildServiceResource" />.
    /// To get a <see cref="SupportedBuildpackResourceCollection" /> instance call the GetSupportedBuildpackResources method from an instance of <see cref="AppBuildServiceResource" />.
    /// </summary>
    public partial class SupportedBuildpackResourceCollection : ArmCollection, IEnumerable<SupportedBuildpackResource>, IAsyncEnumerable<SupportedBuildpackResource>
    {
        private readonly ClientDiagnostics _supportedBuildpackResourceBuildServiceClientDiagnostics;
        private readonly BuildServiceRestOperations _supportedBuildpackResourceBuildServiceRestClient;

        /// <summary> Initializes a new instance of the <see cref="SupportedBuildpackResourceCollection"/> class for mocking. </summary>
        protected SupportedBuildpackResourceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SupportedBuildpackResourceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SupportedBuildpackResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _supportedBuildpackResourceBuildServiceClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppPlatform", SupportedBuildpackResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SupportedBuildpackResource.ResourceType, out string supportedBuildpackResourceBuildServiceApiVersion);
            _supportedBuildpackResourceBuildServiceRestClient = new BuildServiceRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, supportedBuildpackResourceBuildServiceApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AppBuildServiceResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AppBuildServiceResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get the supported buildpack resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/buildServices/{buildServiceName}/supportedBuildpacks/{buildpackName}
        /// Operation Id: BuildService_GetSupportedBuildpack
        /// </summary>
        /// <param name="buildpackName"> The name of the buildpack resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="buildpackName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="buildpackName"/> is null. </exception>
        public virtual async Task<Response<SupportedBuildpackResource>> GetAsync(string buildpackName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(buildpackName, nameof(buildpackName));

            using var scope = _supportedBuildpackResourceBuildServiceClientDiagnostics.CreateScope("SupportedBuildpackResourceCollection.Get");
            scope.Start();
            try
            {
                var response = await _supportedBuildpackResourceBuildServiceRestClient.GetSupportedBuildpackAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, buildpackName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupportedBuildpackResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the supported buildpack resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/buildServices/{buildServiceName}/supportedBuildpacks/{buildpackName}
        /// Operation Id: BuildService_GetSupportedBuildpack
        /// </summary>
        /// <param name="buildpackName"> The name of the buildpack resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="buildpackName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="buildpackName"/> is null. </exception>
        public virtual Response<SupportedBuildpackResource> Get(string buildpackName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(buildpackName, nameof(buildpackName));

            using var scope = _supportedBuildpackResourceBuildServiceClientDiagnostics.CreateScope("SupportedBuildpackResourceCollection.Get");
            scope.Start();
            try
            {
                var response = _supportedBuildpackResourceBuildServiceRestClient.GetSupportedBuildpack(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, buildpackName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupportedBuildpackResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get all supported buildpacks.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/buildServices/{buildServiceName}/supportedBuildpacks
        /// Operation Id: BuildService_ListSupportedBuildpacks
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SupportedBuildpackResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SupportedBuildpackResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SupportedBuildpackResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _supportedBuildpackResourceBuildServiceClientDiagnostics.CreateScope("SupportedBuildpackResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _supportedBuildpackResourceBuildServiceRestClient.ListSupportedBuildpacksAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SupportedBuildpackResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Get all supported buildpacks.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/buildServices/{buildServiceName}/supportedBuildpacks
        /// Operation Id: BuildService_ListSupportedBuildpacks
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupportedBuildpackResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SupportedBuildpackResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SupportedBuildpackResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _supportedBuildpackResourceBuildServiceClientDiagnostics.CreateScope("SupportedBuildpackResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _supportedBuildpackResourceBuildServiceRestClient.ListSupportedBuildpacks(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SupportedBuildpackResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/buildServices/{buildServiceName}/supportedBuildpacks/{buildpackName}
        /// Operation Id: BuildService_GetSupportedBuildpack
        /// </summary>
        /// <param name="buildpackName"> The name of the buildpack resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="buildpackName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="buildpackName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string buildpackName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(buildpackName, nameof(buildpackName));

            using var scope = _supportedBuildpackResourceBuildServiceClientDiagnostics.CreateScope("SupportedBuildpackResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = await _supportedBuildpackResourceBuildServiceRestClient.GetSupportedBuildpackAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, buildpackName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/buildServices/{buildServiceName}/supportedBuildpacks/{buildpackName}
        /// Operation Id: BuildService_GetSupportedBuildpack
        /// </summary>
        /// <param name="buildpackName"> The name of the buildpack resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="buildpackName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="buildpackName"/> is null. </exception>
        public virtual Response<bool> Exists(string buildpackName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(buildpackName, nameof(buildpackName));

            using var scope = _supportedBuildpackResourceBuildServiceClientDiagnostics.CreateScope("SupportedBuildpackResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = _supportedBuildpackResourceBuildServiceRestClient.GetSupportedBuildpack(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, buildpackName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SupportedBuildpackResource> IEnumerable<SupportedBuildpackResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SupportedBuildpackResource> IAsyncEnumerable<SupportedBuildpackResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
