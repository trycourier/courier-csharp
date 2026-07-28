using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Inbox.Messages;

namespace TryCourier.Services.Inbox;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Delete a user's inbox message. The message is removed from every inbox read (it
    /// stops appearing in the recipient's Inbox); it can be restored.
    /// </summary>
    Task Delete(MessageDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(MessageDeleteParams, CancellationToken)"/>
    Task Delete(
        string messageID,
        MessageDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restore a previously deleted inbox message.
    /// </summary>
    Task Restore(MessageRestoreParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Restore(MessageRestoreParams, CancellationToken)"/>
    Task Restore(
        string messageID,
        MessageRestoreParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMessageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /inbox/messages/{message_id}</c>, but is otherwise the
    /// same as <see cref="IMessageService.Delete(MessageDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        MessageDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(MessageDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string messageID,
        MessageDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /inbox/messages/{message_id}/restore</c>, but is otherwise the
    /// same as <see cref="IMessageService.Restore(MessageRestoreParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Restore(
        MessageRestoreParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Restore(MessageRestoreParams, CancellationToken)"/>
    Task<HttpResponse> Restore(
        string messageID,
        MessageRestoreParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
