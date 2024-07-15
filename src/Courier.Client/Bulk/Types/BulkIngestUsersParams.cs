using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record BulkIngestUsersParams
{
    [JsonPropertyName("users")]
    public IEnumerable<InboundBulkMessageUser> Users { get; init; } =
        new List<InboundBulkMessageUser>();
}
