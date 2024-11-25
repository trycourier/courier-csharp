using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BaseSocialPresence
{
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
