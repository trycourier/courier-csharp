using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AudienceMemberGetResponse
{
    [JsonPropertyName("audienceMember")]
    public required AudienceMember AudienceMember { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
