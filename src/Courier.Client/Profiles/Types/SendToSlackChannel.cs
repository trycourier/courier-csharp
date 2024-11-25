using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SendToSlackChannel
{
    [JsonPropertyName("channel")]
    public required string Channel { get; set; }

    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
