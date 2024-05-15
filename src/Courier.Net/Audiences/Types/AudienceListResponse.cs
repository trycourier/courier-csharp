using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AudienceListResponse
{
    [JsonPropertyName("items")]
    public List<Audience> Items { get; init; }

    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }
}
