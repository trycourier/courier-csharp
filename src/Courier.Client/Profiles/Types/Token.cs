using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Token
{
    [JsonPropertyName("token")]
    public required string Token_ { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
