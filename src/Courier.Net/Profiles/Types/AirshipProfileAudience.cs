using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record AirshipProfileAudience
{
    [JsonPropertyName("named_user")]
    public required string NamedUser { get; init; }
}
