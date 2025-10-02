using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record MessageDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique identifier associated with the message you wish to retrieve (results from a send).
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The current status of the message.
    /// </summary>
    [JsonPropertyName("status")]
    public required MessageStatus Status { get; set; }

    /// <summary>
    /// A UTC timestamp at which Courier received the message request. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("enqueued")]
    public required long Enqueued { get; set; }

    /// <summary>
    /// A UTC timestamp at which Courier passed the message to the Integration provider. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("sent")]
    public required long Sent { get; set; }

    /// <summary>
    /// A UTC timestamp at which the Integration provider delivered the message. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("delivered")]
    public required long Delivered { get; set; }

    /// <summary>
    /// A UTC timestamp at which the recipient opened a message for the first time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("opened")]
    public required long Opened { get; set; }

    /// <summary>
    /// A UTC timestamp at which the recipient clicked on a tracked link for the first time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    [JsonPropertyName("clicked")]
    public required long Clicked { get; set; }

    /// <summary>
    /// A unique identifier associated with the recipient of the delivered message.
    /// </summary>
    [JsonPropertyName("recipient")]
    public required string Recipient { get; set; }

    /// <summary>
    /// A unique identifier associated with the event of the delivered message.
    /// </summary>
    [JsonPropertyName("event")]
    public required string Event { get; set; }

    /// <summary>
    /// A unique identifier associated with the notification of the delivered message.
    /// </summary>
    [JsonPropertyName("notification")]
    public required string Notification { get; set; }

    /// <summary>
    /// A message describing the error that occurred.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// The reason for the current status of the message.
    /// </summary>
    [JsonPropertyName("reason")]
    public Reason? Reason { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
