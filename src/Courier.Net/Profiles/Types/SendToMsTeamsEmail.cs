using System.Text.Json.Serialization;

namespace Courier.Net;

public class SendToMsTeamsEmail
{
    [JsonPropertyName("email")]
    public string Email { get; init; }

    [JsonPropertyName("tenant_id")]
    public string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public string ServiceUrl { get; init; }
}
