using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record AudienceListResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<Audience> Items { get; init; } = new List<Audience>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }
}
