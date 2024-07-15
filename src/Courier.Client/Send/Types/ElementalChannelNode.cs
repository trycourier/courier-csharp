using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record ElementalChannelNode
{
    /// <summary>
    /// The channel the contents of this element should be applied to. Can be `email`,
    /// `push`, `direct_message`, `sms` or a provider such as slack
    /// </summary>
    [JsonPropertyName("channel")]
    public required string Channel { get; init; }

    /// <summary>
    /// An array of elements to apply to the channel. If `raw` has not been
    /// specified, `elements` is `required`.
    /// </summary>
    [JsonPropertyName("elements")]
    public IEnumerable<object>? Elements { get; init; }

    /// <summary>
    /// Raw data to apply to the channel. If `elements` has not been
    /// specified, `raw` is `required`.
    /// </summary>
    [JsonPropertyName("raw")]
    public Dictionary<string, object>? Raw { get; init; }

    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("loop")]
    public string? Loop { get; init; }
}
