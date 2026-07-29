using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Send;

namespace TryCourier.Services;

/// <summary>
/// Send a message to one or more recipients — users, lists, audiences, or tenants
/// — across every channel you have configured.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Sends a message to one or more recipients and returns a requestId. Courier
    /// routes it to email, SMS, push, chat, or in-app based on your rules.
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
    /// Returns a raw HTTP response for <c>post /send</c>, but is otherwise the
    /// same as <see cref="ISendService.Message(SendMessageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SendMessageResponse>> Message(
        SendMessageParams parameters,
        CancellationToken cancellationToken = default
    );
}
