using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record AudienceRecipient
{
    /// <summary>
    /// A unique identifier associated with an Audience. A message will be sent to each user in the audience.
    /// </summary>
    [JsonPropertyName("audience_id")]
    public required string AudienceId { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }

    [JsonPropertyName("filters")]
    public IEnumerable<AudienceFilter>? Filters { get; init; }
}
