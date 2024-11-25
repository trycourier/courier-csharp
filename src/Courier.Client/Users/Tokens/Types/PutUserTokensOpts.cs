using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record PutUserTokensOpts
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    [JsonPropertyName("tokens")]
    public IEnumerable<UserToken> Tokens { get; set; } = new List<UserToken>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
