using System.Text.Json.Serialization;

namespace Courier.Net;

public class SendToMsTeamsUserId
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }

    [JsonPropertyName("tenant_id")]
    public string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public string ServiceUrl { get; init; }
}
