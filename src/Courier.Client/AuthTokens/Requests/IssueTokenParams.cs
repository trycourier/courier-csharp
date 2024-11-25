using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record IssueTokenParams
{
    [JsonPropertyName("scope")]
    public required string Scope { get; set; }

    [JsonPropertyName("expires_in")]
    public required string ExpiresIn { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
