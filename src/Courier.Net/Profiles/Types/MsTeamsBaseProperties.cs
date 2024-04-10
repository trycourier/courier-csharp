using System.Text.Json.Serialization;

namespace Courier.Net;

public class MsTeamsBaseProperties
{
    [JsonPropertyName("tenant_id")]
    public string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public string ServiceUrl { get; init; }
}
