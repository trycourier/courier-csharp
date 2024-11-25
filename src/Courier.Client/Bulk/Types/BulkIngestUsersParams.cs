using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BulkIngestUsersParams
{
    [JsonPropertyName("users")]
    public IEnumerable<InboundBulkMessageUser> Users { get; set; } =
        new List<InboundBulkMessageUser>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
