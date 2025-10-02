using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record IssueTokenParams
{
    [JsonPropertyName("scope")]
    public required string Scope { get; set; }

    [JsonPropertyName("expires_in")]
    public required string ExpiresIn { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
