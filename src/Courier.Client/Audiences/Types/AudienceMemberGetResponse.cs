using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record AudienceMemberGetResponse
{
    [JsonPropertyName("audienceMember")]
    public required AudienceMember AudienceMember { get; init; }
}
