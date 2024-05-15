using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AutomationUpdateProfileStep
{
    [JsonPropertyName("action")]
    public string Action { get; init; }

    [JsonPropertyName("recipient_id")]
    public string RecipientId { get; init; }

    [JsonPropertyName("profile")]
    public object Profile { get; init; }

    [JsonPropertyName("merge")]
    public MergeAlgorithm Merge { get; init; }
}
