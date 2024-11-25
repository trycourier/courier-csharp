using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AudienceMember
{
    [JsonPropertyName("added_at")]
    public required string AddedAt { get; set; }

    [JsonPropertyName("audience_id")]
    public required string AudienceId { get; set; }

    [JsonPropertyName("audience_version")]
    public required int AudienceVersion { get; set; }

    [JsonPropertyName("member_id")]
    public required string MemberId { get; set; }

    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
