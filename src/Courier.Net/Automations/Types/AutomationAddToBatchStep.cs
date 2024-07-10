using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;
using OneOf;

#nullable enable

namespace Courier.Net;

public record AutomationAddToBatchStep
{
    [JsonPropertyName("action")]
    public required string Action { get; init; }

    /// <summary>
    /// Defines the period of inactivity before the batch is released. Specified as an [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations)
    /// </summary>
    [JsonPropertyName("wait_period")]
    public required string WaitPeriod { get; init; }

    /// <summary>
    /// Defines the maximum wait time before the batch should be released. Must be less than wait period. Maximum of 60 days. Specified as an [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations)
    /// </summary>
    [JsonPropertyName("max_wait_period")]
    public required string MaxWaitPeriod { get; init; }

    /// <summary>
    /// If specified, the batch will release as soon as this number is reached
    /// </summary>
    [JsonPropertyName("max_items")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<string, int>>))]
    public OneOf<string, int>? MaxItems { get; init; }

    [JsonPropertyName("retain")]
    public required AutomationAddToBatchRetain Retain { get; init; }

    /// <summary>
    /// Determine the scope of the batching. If user, chosen in this order: recipient, profile.user_id, data.user_id, data.userId.
    /// If dynamic, then specify where the batch_key or a reference to the batch_key
    /// </summary>
    [JsonPropertyName("scope")]
    public AutomationAddToBatchScope? Scope { get; init; }

    /// <summary>
    /// If using scope=dynamic, provide the key or a reference (e.g., refs.data.batch_key)
    /// </summary>
    [JsonPropertyName("batch_key")]
    public string? BatchKey { get; init; }

    [JsonPropertyName("batch_id")]
    public string? BatchId { get; init; }

    /// <summary>
    /// Defines the field of the data object the batch is set to when complete. Defaults to `batch`
    /// </summary>
    [JsonPropertyName("category_key")]
    public string? CategoryKey { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
