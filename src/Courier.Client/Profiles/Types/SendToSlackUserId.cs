using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SendToSlackUserId
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
