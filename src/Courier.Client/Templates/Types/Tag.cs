using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record Tag
{
    [JsonPropertyName("data")]
    public IEnumerable<TagData> Data { get; init; } = new List<TagData>();
}
