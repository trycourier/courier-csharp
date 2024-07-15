using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record IssueTokenResponse
{
    [JsonPropertyName("token")]
    public string? Token { get; init; }
}
