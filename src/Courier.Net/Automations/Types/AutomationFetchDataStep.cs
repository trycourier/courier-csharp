using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AutomationFetchDataStep
{
    [JsonPropertyName("action")]
    public string Action { get; init; }

    [JsonPropertyName("webhook")]
    public AutomationFetchDataWebhook Webhook { get; init; }

    [JsonPropertyName("merge_strategy")]
    public MergeAlgorithm MergeStrategy { get; init; }

    [JsonPropertyName("idempotency_expiry")]
    public string? IdempotencyExpiry { get; init; }

    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
