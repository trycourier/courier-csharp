using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BulkIngestUsersParams
{
    [JsonPropertyName("users")]
    public List<InboundBulkMessageUser> Users { get; init; }
}
