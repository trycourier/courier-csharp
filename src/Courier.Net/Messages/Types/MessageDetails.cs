using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class MessageDetails
{
    /// <summary>
    /// A unique identifier associated with the message you wish to retrieve (results from a send).
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }

    /// <summary>
    /// The current status of the message.
    /// </summary>
    [JsonPropertyName("status")]
    public MessageStatus Status { get; init; }

    /// <summary>
    /// A UTC timestamp at which Courier received the message request. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("enqueued")]
    public int Enqueued { get; init; }

    /// <summary>
    /// A UTC timestamp at which Courier passed the message to the Integration provider. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("sent")]
    public int Sent { get; init; }

    /// <summary>
    /// A UTC timestamp at which the Integration provider delivered the message. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("delivered")]
    public int Delivered { get; init; }

    /// <summary>
    /// A UTC timestamp at which the recipient opened a message for the first time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("opened")]
    public int Opened { get; init; }

    /// <summary>
    /// A UTC timestamp at which the recipient clicked on a tracked link for the first time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("clicked")]
    public int Clicked { get; init; }

    /// <summary>
    /// A unique identifier associated with the recipient of the delivered message.
    /// </summary>
    [JsonPropertyName("recipient")]
    public string Recipient { get; init; }

    /// <summary>
    /// A unique identifier associated with the event of the delivered message.
    /// </summary>
    [JsonPropertyName("event")]
    public string Event { get; init; }

    /// <summary>
    /// A unique identifier associated with the notification of the delivered message.
    /// </summary>
    [JsonPropertyName("notification")]
    public string Notification { get; init; }

    /// <summary>
    /// A message describing the error that occurred.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; init; }

    /// <summary>
    /// The reason for the current status of the message.
    /// </summary>
    [JsonPropertyName("reason")]
    public Reason? Reason { get; init; }
}
