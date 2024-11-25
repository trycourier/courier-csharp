using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Utm
{
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("medium")]
    public string? Medium { get; set; }

    [JsonPropertyName("campaign")]
    public string? Campaign { get; set; }

    [JsonPropertyName("term")]
    public string? Term { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
