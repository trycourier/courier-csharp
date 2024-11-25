using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record PutUserTokenOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    [JsonPropertyName("token")]
    public required UserToken Token { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
