using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BulkIngestUsersResponse
{
    [JsonPropertyName("total")]
    public required int Total { get; set; }

    [JsonPropertyName("errors")]
    public IEnumerable<BulkIngestError>? Errors { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
