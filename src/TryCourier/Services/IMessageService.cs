using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Messages;

namespace TryCourier.Services;

/// <summary>
/// Look up the messages Courier has accepted, inspect their delivery history and
/// rendered output, and cancel, resend, or archive them.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Returns a sent message's status, recipient, event, and per-provider delivery
    /// detail, with timestamps for enqueued, sent, delivered, opened, and clicked.
    /// </summary>
    Task<MessageRetrieveResponse> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MessageRetrieveParams, CancellationToken)"/>
    Task<MessageRetrieveResponse> Retrieve(
        string messageID,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns previously sent messages, most recent first, each carrying its status,
    /// recipient, channel, and provider. Paged by cursor.
    /// </summary>
    Task<MessageListResponse> List(
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a message that is still in the delivery pipeline and returns the message
    /// record with its resulting canceled or failed status.
    /// </summary>
    Task<MessageDetails> Cancel(
        MessageCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(MessageCancelParams, CancellationToken)"/>
    Task<MessageDetails> Cancel(
        string messageID,
        MessageCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the rendered content Courier delivered for a message, broken out per
    /// channel, to confirm what the recipient received.
    /// </summary>
    Task<MessageContentResponse> Content(
        MessageContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Content(MessageContentParams, CancellationToken)"/>
    Task<MessageContentResponse> Content(
        string messageID,
        MessageContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the ordered event history for a sent message, one entry per status
    /// transition with its timestamp.
    /// </summary>
    Task<MessageHistoryResponse> History(
        MessageHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="History(MessageHistoryParams, CancellationToken)"/>
    Task<MessageHistoryResponse> History(
        string messageID,
        MessageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Resends a previously sent message to the same recipient and content, returning a
    /// new messageId. The original send request is not modified.
    /// </summary>
    Task<MessageResendResponse> Resend(
        MessageResendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Resend(MessageResendParams, CancellationToken)"/>
    Task<MessageResendResponse> Resend(
        string messageID,
        MessageResendParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>get /messages/{message_id}</c>, but is otherwise the
    /// same as <see cref="IMessageService.Retrieve(MessageRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MessageRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        string messageID,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /messages</c>, but is otherwise the
    /// same as <see cref="IMessageService.List(MessageListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageListResponse>> List(
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /messages/{message_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IMessageService.Cancel(MessageCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageDetails>> Cancel(
        MessageCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(MessageCancelParams, CancellationToken)"/>
    Task<HttpResponse<MessageDetails>> Cancel(
        string messageID,
        MessageCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /messages/{message_id}/output</c>, but is otherwise the
    /// same as <see cref="IMessageService.Content(MessageContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageContentResponse>> Content(
        MessageContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Content(MessageContentParams, CancellationToken)"/>
    Task<HttpResponse<MessageContentResponse>> Content(
        string messageID,
        MessageContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /messages/{message_id}/history</c>, but is otherwise the
    /// same as <see cref="IMessageService.History(MessageHistoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageHistoryResponse>> History(
        MessageHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="History(MessageHistoryParams, CancellationToken)"/>
    Task<HttpResponse<MessageHistoryResponse>> History(
        string messageID,
        MessageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /messages/{message_id}/resend</c>, but is otherwise the
    /// same as <see cref="IMessageService.Resend(MessageResendParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageResendResponse>> Resend(
        MessageResendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Resend(MessageResendParams, CancellationToken)"/>
    Task<HttpResponse<MessageResendResponse>> Resend(
        string messageID,
        MessageResendParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
