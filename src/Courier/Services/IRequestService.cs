using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Requests;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRequestService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRequestServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Archive message
    /// </summary>
    Task Archive(RequestArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(RequestArchiveParams, CancellationToken)"/>
    Task Archive(
        string requestID,
        RequestArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRequestService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRequestServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequestServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `put /requests/{request_id}/archive`, but is otherwise the
    /// same as <see cref="IRequestService.Archive(RequestArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        RequestArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(RequestArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string requestID,
        RequestArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
