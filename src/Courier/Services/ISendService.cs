using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Send;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISendService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISendServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISendService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Send a message to one or more recipients.
    /// </summary>
    Task<SendMessageResponse> Message(
        SendMessageParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISendService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISendServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISendServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /send`, but is otherwise the
    /// same as <see cref="ISendService.Message(SendMessageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SendMessageResponse>> Message(
        SendMessageParams parameters,
        CancellationToken cancellationToken = default
    );
}
