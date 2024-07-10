using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record BaseCheck
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("status")]
    public required CheckStatus Status { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
