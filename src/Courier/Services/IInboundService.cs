using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Inbound;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInboundService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInboundServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Courier Track Event
    /// </summary>
    Task<InboundTrackEventResponse> TrackEvent(
        InboundTrackEventParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInboundService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInboundServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInboundServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /inbound/courier`, but is otherwise the
    /// same as <see cref="IInboundService.TrackEvent(InboundTrackEventParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InboundTrackEventResponse>> TrackEvent(
        InboundTrackEventParams parameters,
        CancellationToken cancellationToken = default
    );
}
