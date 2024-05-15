using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AudienceMemberListResponse
{
    [JsonPropertyName("items")]
    public List<AudienceMember> Items { get; init; }

    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }
}
