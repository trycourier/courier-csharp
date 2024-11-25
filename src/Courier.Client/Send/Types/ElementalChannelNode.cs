using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ElementalChannelNode
{
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
    public IEnumerable<object>? Elements { get; set; }

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
