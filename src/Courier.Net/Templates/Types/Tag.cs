using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record Tag
{
    [JsonPropertyName("data")]
    public IEnumerable<TagData> Data { get; init; } = new List<TagData>();
}
