using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record AutomationUpdateProfileStep
{
    [JsonPropertyName("action")]
    public required string Action { get; init; }

    [JsonPropertyName("recipient_id")]
    public required string RecipientId { get; init; }

    [JsonPropertyName("profile")]
    public required object Profile { get; init; }

    [JsonPropertyName("merge")]
    public required MergeAlgorithm Merge { get; init; }
}
