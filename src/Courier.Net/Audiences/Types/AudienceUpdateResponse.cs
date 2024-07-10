using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record AudienceUpdateResponse
{
    [JsonPropertyName("audience")]
    public required Audience Audience { get; init; }
}
