using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record MessageDetails
{
    /// <summary>
    /// A unique identifier associated with the message you wish to retrieve (results from a send).
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// The current status of the message.
    /// </summary>
    [JsonPropertyName("status")]
    public required MessageStatus Status { get; init; }

    /// <summary>
    /// A UTC timestamp at which Courier received the message request. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("enqueued")]
    public required int Enqueued { get; init; }

    /// <summary>
    /// A UTC timestamp at which Courier passed the message to the Integration provider. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("sent")]
    public required int Sent { get; init; }

    /// <summary>
    /// A UTC timestamp at which the Integration provider delivered the message. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("delivered")]
    public required int Delivered { get; init; }

    /// <summary>
    /// A UTC timestamp at which the recipient opened a message for the first time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("opened")]
    public required int Opened { get; init; }

    /// <summary>
    /// A UTC timestamp at which the recipient clicked on a tracked link for the first time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("clicked")]
    public required int Clicked { get; init; }

    /// <summary>
    /// A unique identifier associated with the recipient of the delivered message.
    /// </summary>
    [JsonPropertyName("recipient")]
    public required string Recipient { get; init; }

    /// <summary>
    /// A unique identifier associated with the event of the delivered message.
    /// </summary>
    [JsonPropertyName("event")]
    public required string Event { get; init; }

    /// <summary>
    /// A unique identifier associated with the notification of the delivered message.
    /// </summary>
    [JsonPropertyName("notification")]
    public required string Notification { get; init; }

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
