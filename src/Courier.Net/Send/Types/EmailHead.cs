using System.Text.Json.Serialization;

namespace Courier.Net;

public class EmailHead
{
    [JsonPropertyName("inheritDefault")]
    public bool InheritDefault { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }
}
