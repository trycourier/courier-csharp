using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class Tag
{
    [JsonPropertyName("data")]
    public List<TagData> Data { get; init; }
}
