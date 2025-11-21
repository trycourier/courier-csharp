using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Messages;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessageService
{
    IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Fetch the status of a message you've previously sent.
    /// </summary>
    Task<MessageRetrieveResponse> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch the status of a message you've previously sent.
    /// </summary>
    Task<MessageRetrieveResponse> Retrieve(
        string messageID,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch the statuses of messages you've previously sent.
    /// </summary>
    Task<MessageListResponse> List(
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a message that is currently in the process of being delivered. A well-formatted
    /// API call to the cancel message API will return either `200` status code for
    /// a successful cancellation or `409` status code for an unsuccessful cancellation.
    /// Both cases will include the actual message record in the response body (see
    /// details below).
    /// </summary>
    Task<MessageDetails> Cancel(
        MessageCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a message that is currently in the process of being delivered. A well-formatted
    /// API call to the cancel message API will return either `200` status code for
    /// a successful cancellation or `409` status code for an unsuccessful cancellation.
    /// Both cases will include the actual message record in the response body (see
    /// details below).
    /// </summary>
    Task<MessageDetails> Cancel(
        string messageID,
        MessageCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get message content
    /// </summary>
    Task<MessageContentResponse> Content(
        MessageContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get message content
    /// </summary>
    Task<MessageContentResponse> Content(
        string messageID,
        MessageContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch the array of events of a message you've previously sent.
    /// </summary>
    Task<MessageHistoryResponse> History(
        MessageHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch the array of events of a message you've previously sent.
    /// </summary>
    Task<MessageHistoryResponse> History(
        string messageID,
        MessageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
