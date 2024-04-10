using System.Text.Json.Serialization;

namespace Courier.Net;

public class SendToMsTeamsChannelName
{
    [JsonPropertyName("channel_name")]
    public string ChannelName { get; init; }

    [JsonPropertyName("team_id")]
    public string TeamId { get; init; }

    [JsonPropertyName("tenant_id")]
    public string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public string ServiceUrl { get; init; }
}
