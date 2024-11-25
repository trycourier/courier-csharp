using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BrandGetAllResponse
{
    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    [JsonPropertyName("results")]
    public IEnumerable<Brand> Results { get; set; } = new List<Brand>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
