using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AudienceMemberListResponse
{
    [JsonPropertyName("items")]
    public IEnumerable<AudienceMember> Items { get; set; } = new List<AudienceMember>();

    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
