using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

/// <summary>
/// The channel element allows a notification to be customized based on which channel it is sent through.
/// For example, you may want to display a detailed message when the notification is sent through email,
/// and a more concise message in a push notification. Channel elements are only valid as top-level
/// elements; you cannot nest channel elements. If there is a channel element specified at the top-level
/// of the document, all sibling elements must be channel elements.
/// Note: As an alternative, most elements support a `channel` property. Which allows you to selectively
/// display an individual element on a per channel basis. See the
/// [control flow docs](https://www.courier.com/docs/platform/content/elemental/control-flow/) for more details.
/// </summary>
[Serializable]
public record ElementalChannelNode : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The channel the contents of this element should be applied to. Can be `email`,
    /// `push`, `direct_message`, `sms` or a provider such as slack
    /// </summary>
    [JsonPropertyName("channel")]
    public required string Channel { get; set; }

    /// <summary>
    /// An array of elements to apply to the channel. If `raw` has not been
    /// specified, `elements` is `required`.
    /// </summary>
    [JsonPropertyName("elements")]
    public IEnumerable<ElementalNode>? Elements { get; set; }

    /// <summary>
    /// Raw data to apply to the channel. If `elements` has not been
    /// specified, `raw` is `required`.
    /// </summary>
    [JsonPropertyName("raw")]
    public Dictionary<string, object?>? Raw { get; set; }

    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("loop")]
    public string? Loop { get; set; }

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
