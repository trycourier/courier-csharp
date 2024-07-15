using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record ElementalMetaNode
{
    /// <summary>
    /// The title to be displayed by supported channels. For example, the email subject.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("loop")]
    public string? Loop { get; init; }
}
