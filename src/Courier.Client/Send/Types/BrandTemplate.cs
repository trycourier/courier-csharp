using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record BrandTemplate
{
    [JsonPropertyName("backgroundColor")]
    public string? BackgroundColor { get; init; }

    [JsonPropertyName("blocksBackgroundColor")]
    public string? BlocksBackgroundColor { get; init; }

    [JsonPropertyName("enabled")]
    public required bool Enabled { get; init; }

    [JsonPropertyName("footer")]
    public string? Footer { get; init; }

    [JsonPropertyName("head")]
    public string? Head { get; init; }

    [JsonPropertyName("header")]
    public string? Header { get; init; }

    [JsonPropertyName("width")]
    public string? Width { get; init; }
}
