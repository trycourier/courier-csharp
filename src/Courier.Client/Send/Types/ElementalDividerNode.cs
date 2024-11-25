using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ElementalDividerNode
{
    /// <summary>
    /// The CSS color to render the line with. For example, `#fff`
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

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
