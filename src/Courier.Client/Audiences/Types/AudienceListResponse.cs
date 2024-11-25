using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AudienceListResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<Audience> Items { get; set; } = new List<Audience>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
