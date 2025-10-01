using System.Threading.Tasks;
using Courier.Models.Messages;

namespace Courier.Services.Messages;

public interface IMessageService
{
    /// <summary>
    /// Fetch the status of a message you've previously sent.
    /// </summary>
    Task<MessageRetrieveResponse> Retrieve(MessageRetrieveParams parameters);

    /// <summary>
    /// Fetch the statuses of messages you've previously sent.
    /// </summary>
    Task<MessageListResponse> List(MessageListParams? parameters = null);

    /// <summary>
    /// Cancel a message that is currently in the process of being delivered. A well-formatted
    /// API call to the cancel message API will return either `200` status code for
    /// a successful cancellation or `409` status code for an unsuccessful cancellation.
    /// Both cases will include the actual message record in the response body (see
    /// details below).
    /// </summary>
    Task<MessageDetails> Cancel(MessageCancelParams parameters);

    /// <summary>
    /// Get message content
    /// </summary>
    Task<MessageGetContentResponse> GetContent(MessageGetContentParams parameters);

    /// <summary>
    /// Fetch the array of events of a message you've previously sent.
    /// </summary>
    Task<MessageHistoryResponse> History(MessageHistoryParams parameters);
}
