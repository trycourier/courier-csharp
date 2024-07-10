using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record AudienceMemberListResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<AudienceMember> Items { get; init; } = new List<AudienceMember>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }
}
