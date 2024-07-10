using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record SendToMsTeamsUserId
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; init; }

    [JsonPropertyName("tenant_id")]
    public required string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public required string ServiceUrl { get; init; }
}
