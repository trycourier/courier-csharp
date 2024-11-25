using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AudienceUpdateResponse
{
    [JsonPropertyName("audience")]
    public required Audience Audience { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
