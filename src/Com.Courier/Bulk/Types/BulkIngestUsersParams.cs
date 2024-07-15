using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BulkIngestUsersParams
{
    [JsonPropertyName("users")]
    public IEnumerable<InboundBulkMessageUser> Users { get; init; } =
        new List<InboundBulkMessageUser>();
}
