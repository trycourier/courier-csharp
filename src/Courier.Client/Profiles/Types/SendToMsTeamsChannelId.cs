using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SendToMsTeamsChannelId
{
    [JsonPropertyName("channel_id")]
    public required string ChannelId { get; set; }

    [JsonPropertyName("tenant_id")]
    public required string TenantId { get; set; }

    [JsonPropertyName("service_url")]
    public required string ServiceUrl { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
