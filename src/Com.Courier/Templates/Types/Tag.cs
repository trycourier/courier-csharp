using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record Tag
{
    [JsonPropertyName("data")]
    public IEnumerable<TagData> Data { get; init; } = new List<TagData>();
}
