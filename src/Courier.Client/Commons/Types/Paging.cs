using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record Paging
{
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }

    [JsonPropertyName("more")]
    public required bool More { get; init; }
}
