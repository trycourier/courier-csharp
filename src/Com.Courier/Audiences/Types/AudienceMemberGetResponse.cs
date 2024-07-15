using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record AudienceMemberGetResponse
{
    [JsonPropertyName("audienceMember")]
    public required AudienceMember AudienceMember { get; init; }
}
