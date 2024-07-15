using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record BrandGetAllResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    [JsonPropertyName("results")]
    public IEnumerable<Brand> Results { get; init; } = new List<Brand>();
}
