using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record AudienceUpdateResponse
{
    [JsonPropertyName("audience")]
    public required Audience Audience { get; init; }
}
