using System.Text.Json.Serialization;

namespace Courier.Net;

public class Utm
{
    [JsonPropertyName("source")]
    public string? Source { get; init; }

    [JsonPropertyName("medium")]
    public string? Medium { get; init; }

    [JsonPropertyName("campaign")]
    public string? Campaign { get; init; }

    [JsonPropertyName("term")]
    public string? Term { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }
}
