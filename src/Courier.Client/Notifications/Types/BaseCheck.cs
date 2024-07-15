using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record BaseCheck
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("status")]
    public required CheckStatus Status { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
