using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Providers;
using TryCourier.Services.Providers;

namespace TryCourier.Services;

/// <summary>
/// Configure the channel providers Courier delivers through, and browse the provider
/// types it supports.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Configures a provider integration from a Courier provider key and its settings.
    /// Check the catalog endpoint for the schema each provider expects.
    /// </summary>
    Task<Provider> Create(
        ProviderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one configured provider by id, including its channel, provider key,
    /// alias, title, and current settings.
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
    /// Replaces a provider's configuration in full, clearing any field you omit rather
    /// than merging it. Send the complete settings object.
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
    /// Lists the provider integrations configured in the workspace, one entry per
    /// channel and provider key with its alias and settings.
    /// </summary>
    Task<ProviderListResponse> List(
        ProviderListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a provider configuration, which fails while routing strategies or
    /// templates still reference it. Update those references first.
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
