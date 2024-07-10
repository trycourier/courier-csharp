using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record SendToMsTeamsConversationId
{
    [JsonPropertyName("conversation_id")]
    public required string ConversationId { get; init; }

    [JsonPropertyName("tenant_id")]
    public required string TenantId { get; init; }

    [JsonPropertyName("service_url")]
    public required string ServiceUrl { get; init; }
}
