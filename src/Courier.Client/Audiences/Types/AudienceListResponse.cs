using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record AudienceListResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<Audience> Items { get; init; } = new List<Audience>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }
}
