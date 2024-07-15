using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record SendToMsTeamsChannelName
{
    [JsonPropertyName("channel_name")]
    public required string ChannelName { get; init; }

    [JsonPropertyName("team_id")]
    public required string TeamId { get; init; }

    [JsonPropertyName("tenant_id")]
    public required string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public required string ServiceUrl { get; init; }
}
