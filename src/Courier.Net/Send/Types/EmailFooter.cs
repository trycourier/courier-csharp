using System.Text.Json.Serialization;

namespace Courier.Net;

public class EmailFooter
{
    [JsonPropertyName("content")]
    public object? Content { get; init; }

    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; init; }
}
