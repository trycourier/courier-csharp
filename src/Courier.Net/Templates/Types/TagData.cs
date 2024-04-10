using System.Text.Json.Serialization;

namespace Courier.Net;

public class TagData
{
    /// <summary>
    /// A unique identifier of the tag.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }

    /// <summary>
    /// Name of the tag.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }
}
