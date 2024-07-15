using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record SendDirectMessage
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }
}
