using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationFetchDataStep
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("webhook")]
    public required AutomationFetchDataWebhook Webhook { get; set; }

    [JsonPropertyName("merge_strategy")]
    public required MergeAlgorithm MergeStrategy { get; set; }

    [JsonPropertyName("idempotency_expiry")]
    public string? IdempotencyExpiry { get; set; }

    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
