using System.Text.Json.Serialization;

namespace Courier.Net;

public class Paging
{
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }

    [JsonPropertyName("more")]
    public bool More { get; init; }
}
