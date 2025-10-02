using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

namespace Courier.Client;

[Serializable]
public record AutomationV2SendStep : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("action")]
    public string Action { get; set; } = "send";

    [JsonPropertyName("message")]
    public required OneOf<ContentMessage, TemplateMessage> Message { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

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
