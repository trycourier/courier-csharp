using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record SendToMsTeamsChannelId
{
    [JsonPropertyName("channel_id")]
    public required string ChannelId { get; init; }

    [JsonPropertyName("tenant_id")]
    public required string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public required string ServiceUrl { get; init; }
}
