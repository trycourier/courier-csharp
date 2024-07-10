namespace Courier.Net;

public record ListMessagesRequest
{
    /// <summary>
    /// A boolean value that indicates whether archived messages should be included in the response.
    /// </summary>
    public bool? Archived { get; init; }

    /// <summary>
    /// A unique identifier that allows for fetching the next set of messages.
    /// </summary>
    public string? Cursor { get; init; }

    /// <summary>
    /// A unique identifier representing the event that was used to send the event.
    /// </summary>
    public string? Event { get; init; }

    /// <summary>
    /// A unique identifier representing the list the message was sent to.
    /// </summary>
    public string? List { get; init; }

    /// <summary>
    /// A unique identifier representing the message_id returned from either /send or /send/list.
    /// </summary>
    public string? MessageId { get; init; }

    /// <summary>
    /// A unique identifier representing the notification that was used to send the event.
    /// </summary>
    public string? Notification { get; init; }

    /// <summary>
    /// The key assocated to the provider you want to filter on. E.g., sendgrid, inbox, twilio, slack, msteams, etc. Allows multiple values to be set in query parameters.
    /// </summary>
    public string? Provider { get; init; }

    /// <summary>
    /// A unique identifier representing the recipient associated with the requested profile.
    /// </summary>
    public string? Recipient { get; init; }

    /// <summary>
    /// An indicator of the current status of the message. Allows multiple values to be set in query parameters.
    /// </summary>
    public string? Status { get; init; }

    /// <summary>
    /// A tag placed in the metadata.tags during a notification send. Allows multiple values to be set in query parameters.
    /// </summary>
    public string? Tag { get; init; }

    /// <summary>
    /// A comma delimited list of 'tags'. Messages will be returned if they match any of the tags passed in.
    /// </summary>
    public string? Tags { get; init; }

    /// <summary>
    /// Messages sent with the context of a Tenant
    /// </summary>
    public string? TenantId { get; init; }

    /// <summary>
    /// The enqueued datetime of a message to filter out messages received before.
    /// </summary>
    public string? EnqueuedAfter { get; init; }

    /// <summary>
    /// The unique identifier used to trace the requests
    /// </summary>
    public string? TraceId { get; init; }
}
