using System.Text.Json.Serialization;

namespace Courier.Net;

public class AudienceMember
{
    [JsonPropertyName("added_at")]
    public string AddedAt { get; init; }

    [JsonPropertyName("audience_id")]
    public string AudienceId { get; init; }

    [JsonPropertyName("audience_version")]
    public int AudienceVersion { get; init; }

    [JsonPropertyName("member_id")]
    public string MemberId { get; init; }

    [JsonPropertyName("reason")]
    public string Reason { get; init; }
}
