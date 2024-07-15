using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BrandGetAllResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    [JsonPropertyName("results")]
    public IEnumerable<Brand> Results { get; init; } = new List<Brand>();
}
