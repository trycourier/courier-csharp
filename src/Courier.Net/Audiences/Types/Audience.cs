using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class Audience
{
    /// <summary>
    /// A unique identifier representing the audience_id
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }

    /// <summary>
    /// The name of the audience
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// A description of the audience
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("filter")]
    public OneOf<SingleFilterConfig, NestedFilterConfig> Filter { get; init; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; }
}
