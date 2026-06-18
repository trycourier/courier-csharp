using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Providers.Catalog;

namespace TryCourier.Services.Providers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICatalogService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICatalogServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICatalogService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the catalog of available provider types with their display names,
    /// descriptions, and configuration schema fields (snake_case, with `type` and
    /// `required`). Providers with no configurable schema return only `provider`,
    /// `name`, and `description`.
    /// </summary>
    Task<CatalogListResponse> List(
        CatalogListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICatalogService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICatalogServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICatalogServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /providers/catalog</c>, but is otherwise the
    /// same as <see cref="ICatalogService.List(CatalogListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CatalogListResponse>> List(
        CatalogListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
