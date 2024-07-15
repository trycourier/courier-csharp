using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record AudienceUpdateResponse
{
    [JsonPropertyName("audience")]
    public required Audience Audience { get; init; }
}
