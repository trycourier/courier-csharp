using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AudienceMemberGetResponse
{
    [JsonPropertyName("audienceMember")]
    public AudienceMember AudienceMember { get; init; }
}
