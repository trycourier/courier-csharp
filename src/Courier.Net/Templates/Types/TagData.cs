using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record TagData
{
    /// <summary>
    /// A unique identifier of the tag.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Name of the tag.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
