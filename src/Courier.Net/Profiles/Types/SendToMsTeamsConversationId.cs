using System.Text.Json.Serialization;

namespace Courier.Net;

public class SendToMsTeamsConversationId
{
    [JsonPropertyName("conversation_id")]
    public string ConversationId { get; init; }

    [JsonPropertyName("tenant_id")]
    public string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public string ServiceUrl { get; init; }
}
