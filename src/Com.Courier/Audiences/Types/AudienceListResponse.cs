using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record AudienceListResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<Audience> Items { get; init; } = new List<Audience>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }
}
