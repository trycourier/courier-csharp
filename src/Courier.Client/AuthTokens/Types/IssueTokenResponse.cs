using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record IssueTokenResponse
{
    [JsonPropertyName("token")]
    public string? Token { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
