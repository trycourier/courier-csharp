using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AudienceRecipient
{
    /// <summary>
    /// A unique identifier associated with an Audience. A message will be sent to each user in the audience.
    /// </summary>
    [JsonPropertyName("audience_id")]
    public string AudienceId { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }

    [JsonPropertyName("filters")]
    public List<AudienceFilter>? Filters { get; init; }
}
