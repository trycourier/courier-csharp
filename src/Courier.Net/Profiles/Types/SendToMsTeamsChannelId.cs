using System.Text.Json.Serialization;

namespace Courier.Net;

public class SendToMsTeamsChannelId
{
    [JsonPropertyName("channel_id")]
    public string ChannelId { get; init; }

    [JsonPropertyName("tenant_id")]
    public string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public string ServiceUrl { get; init; }
}
