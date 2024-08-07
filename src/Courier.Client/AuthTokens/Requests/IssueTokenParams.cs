using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record IssueTokenParams
{
    [JsonPropertyName("scope")]
    public required string Scope { get; init; }

    [JsonPropertyName("expires_in")]
    public required string ExpiresIn { get; init; }
}
