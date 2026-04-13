using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Providers;
using Courier.Services.Providers;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProviderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProviderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProviderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICatalogService Catalog { get; }

    /// <summary>
    /// Create a new provider configuration. The `provider` field must be a known
    /// Courier provider key (see catalog).
    /// </summary>
    Task<Provider> Create(
        ProviderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch a single provider configuration by ID.
    /// </summary>
    Task<Provider> Retrieve(
        ProviderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProviderRetrieveParams, CancellationToken)"/>
    Task<Provider> Retrieve(
        string id,
        ProviderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace an existing provider configuration. The `provider` key is required and
    /// determines which provider-specific settings schema is applied. All other fields
    /// are optional — omitted fields are cleared from the stored configuration (this is
    /// a full replacement, not a partial merge). Changing the provider type for an
    /// existing configuration is not supported.
    /// </summary>
    Task<Provider> Update(
        ProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ProviderUpdateParams, CancellationToken)"/>
    Task<Provider> Update(
        string id,
        ProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List configured provider integrations for the current workspace. Supports
    /// cursor-based pagination.
    /// </summary>
    Task<ProviderListResponse> List(
        ProviderListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a provider configuration. Returns 409 if the provider is still referenced
    /// by routing or notifications.
    /// </summary>
    Task Delete(ProviderDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ProviderDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        ProviderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProviderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProviderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProviderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICatalogServiceWithRawResponse Catalog { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /providers</c>, but is otherwise the
    /// same as <see cref="IProviderService.Create(ProviderCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Provider>> Create(
        ProviderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /providers/{id}</c>, but is otherwise the
    /// same as <see cref="IProviderService.Retrieve(ProviderRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Provider>> Retrieve(
        ProviderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProviderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Provider>> Retrieve(
        string id,
        ProviderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /providers/{id}</c>, but is otherwise the
    /// same as <see cref="IProviderService.Update(ProviderUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Provider>> Update(
        ProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ProviderUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Provider>> Update(
        string id,
        ProviderUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /providers</c>, but is otherwise the
    /// same as <see cref="IProviderService.List(ProviderListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProviderListResponse>> List(
        ProviderListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /providers/{id}</c>, but is otherwise the
    /// same as <see cref="IProviderService.Delete(ProviderDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ProviderDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ProviderDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        ProviderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
