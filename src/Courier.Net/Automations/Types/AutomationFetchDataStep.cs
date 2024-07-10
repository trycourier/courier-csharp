using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record AutomationFetchDataStep
{
    [JsonPropertyName("action")]
    public required string Action { get; init; }

    [JsonPropertyName("webhook")]
    public required AutomationFetchDataWebhook Webhook { get; init; }

    [JsonPropertyName("merge_strategy")]
    public required MergeAlgorithm MergeStrategy { get; init; }

    [JsonPropertyName("idempotency_expiry")]
    public string? IdempotencyExpiry { get; init; }

    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
