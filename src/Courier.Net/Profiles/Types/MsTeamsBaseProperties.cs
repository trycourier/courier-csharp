using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record MsTeamsBaseProperties
{
    [JsonPropertyName("tenant_id")]
    public required string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public required string ServiceUrl { get; init; }
}
