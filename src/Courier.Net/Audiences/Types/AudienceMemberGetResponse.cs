using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record AudienceMemberGetResponse
{
    [JsonPropertyName("audienceMember")]
    public required AudienceMember AudienceMember { get; init; }
}
