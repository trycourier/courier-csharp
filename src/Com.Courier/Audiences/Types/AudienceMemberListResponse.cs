using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record AudienceMemberListResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<AudienceMember> Items { get; init; } = new List<AudienceMember>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }
}
