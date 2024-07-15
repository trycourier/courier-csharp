using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record SendToMsTeamsEmail
{
    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("tenant_id")]
    public required string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public required string ServiceUrl { get; init; }
}
