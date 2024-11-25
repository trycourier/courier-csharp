using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationUpdateProfileStep
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("recipient_id")]
    public required string RecipientId { get; set; }

    [JsonPropertyName("profile")]
    public required object Profile { get; set; }

    [JsonPropertyName("merge")]
    public required MergeAlgorithm Merge { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
