using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AudienceRecipient
{
    /// <summary>
    /// A unique identifier associated with an Audience. A message will be sent to each user in the audience.
    /// </summary>
    [JsonPropertyName("audience_id")]
    public required string AudienceId { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    [JsonPropertyName("filters")]
    public IEnumerable<AudienceFilter>? Filters { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
