using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record BulkIngestUsersParams
{
    [JsonPropertyName("users")]
    public IEnumerable<InboundBulkMessageUser> Users { get; init; } =
        new List<InboundBulkMessageUser>();
}
