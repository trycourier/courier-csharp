using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Email
{
    [JsonPropertyName("footer")]
    public required object Footer { get; init; }

    [JsonPropertyName("header")]
    public required object Header { get; init; }
}
