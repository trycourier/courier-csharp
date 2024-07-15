using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record AudienceMember
{
    [JsonPropertyName("added_at")]
    public required string AddedAt { get; init; }

    [JsonPropertyName("audience_id")]
    public required string AudienceId { get; init; }

    [JsonPropertyName("audience_version")]
    public required int AudienceVersion { get; init; }

    [JsonPropertyName("member_id")]
    public required string MemberId { get; init; }

    [JsonPropertyName("reason")]
    public required string Reason { get; init; }
}
