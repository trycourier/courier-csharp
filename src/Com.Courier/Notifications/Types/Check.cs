using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record Check
{
    [JsonPropertyName("updated")]
    public required long Updated { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("status")]
    public required CheckStatus Status { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
