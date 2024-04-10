using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BrandGetAllResponse
{
    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }

    [JsonPropertyName("results")]
    public List<Brand> Results { get; init; }
}
