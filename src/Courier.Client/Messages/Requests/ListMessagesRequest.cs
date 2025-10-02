using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record ListMessagesRequest
{
    /// <summary>
    /// A boolean value that indicates whether archived messages should be included in the response.
    /// </summary>
    [JsonIgnore]
    public bool? Archived { get; set; }

    /// <summary>
    /// A unique identifier that allows for fetching the next set of messages.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// A unique identifier representing the event that was used to send the event.
    /// </summary>
    [JsonIgnore]
    public string? Event { get; set; }

    /// <summary>
    /// A unique identifier representing the list the message was sent to.
    /// </summary>
    [JsonIgnore]
    public string? List { get; set; }

    /// <summary>
    /// A unique identifier representing the message_id returned from either /send or /send/list.
    /// </summary>
    [JsonIgnore]
    public string? MessageId { get; set; }

    /// <summary>
    /// A unique identifier representing the notification that was used to send the event.
    /// </summary>
    [JsonIgnore]
    public string? Notification { get; set; }

    /// <summary>
    /// The key assocated to the provider you want to filter on. E.g., sendgrid, inbox, twilio, slack, msteams, etc. Allows multiple values to be set in query parameters.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Provider { get; set; } = new List<string>();

    /// <summary>
    /// A unique identifier representing the recipient associated with the requested profile.
    /// </summary>
    [JsonIgnore]
    public string? Recipient { get; set; }

    /// <summary>
    /// An indicator of the current status of the message. Allows multiple values to be set in query parameters.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Status { get; set; } = new List<string>();

    /// <summary>
    /// A tag placed in the metadata.tags during a notification send. Allows multiple values to be set in query parameters.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Tag { get; set; } = new List<string>();

    /// <summary>
    /// A comma delimited list of 'tags'. Messages will be returned if they match any of the tags passed in.
    /// </summary>
    [JsonIgnore]
    public string? Tags { get; set; }

    /// <summary>
    /// Messages sent with the context of a Tenant
    /// </summary>
    [JsonIgnore]
    public string? TenantId { get; set; }

    /// <summary>
    /// The enqueued datetime of a message to filter out messages received before.
    /// </summary>
    [JsonIgnore]
    public string? EnqueuedAfter { get; set; }

    /// <summary>
    /// The unique identifier used to trace the requests
    /// </summary>
    [JsonIgnore]
    public string? TraceId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
