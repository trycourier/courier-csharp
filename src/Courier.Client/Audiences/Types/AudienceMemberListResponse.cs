using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record AudienceMemberListResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<AudienceMember> Items { get; init; } = new List<AudienceMember>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }
}
