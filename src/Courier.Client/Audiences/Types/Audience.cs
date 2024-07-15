using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record Audience
{
    /// <summary>
    /// A unique identifier representing the audience_id
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// The name of the audience
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// A description of the audience
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("filter")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<SingleFilterConfig, NestedFilterConfig>>))]
    public required OneOf<SingleFilterConfig, NestedFilterConfig> Filter { get; init; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; init; }
}
