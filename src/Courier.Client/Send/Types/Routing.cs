using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

namespace Courier.Client;

/// <summary>
/// Allows you to customize which channel(s) Courier will potentially deliver the message.
/// If no routing key is specified, Courier will use the default routing configuration or
/// routing defined by the template.
/// </summary>
[Serializable]
public record Routing : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("method")]
    public required RoutingMethod Method { get; set; }

    /// <summary>
    /// A list of channels or providers to send the message through. Can also recursively define
    /// sub-routing methods, which can be useful for defining advanced push notification
    /// delivery strategies.
    /// </summary>
    [JsonPropertyName("channels")]
    public IEnumerable<OneOf<string, MessageRouting>> Channels { get; set; } =
        new List<OneOf<string, MessageRouting>>();

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
