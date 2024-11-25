using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ElementalMetaNode
{
    /// <summary>
    /// The title to be displayed by supported channels. For example, the email subject.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("loop")]
    public string? Loop { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
