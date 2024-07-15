using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record AirshipProfileAudience
{
    [JsonPropertyName("named_user")]
    public required string NamedUser { get; init; }
}
