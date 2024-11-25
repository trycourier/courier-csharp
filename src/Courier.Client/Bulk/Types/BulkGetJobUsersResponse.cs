using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BulkGetJobUsersResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<BulkMessageUserResponse> Items { get; set; } =
        new List<BulkMessageUserResponse>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
