using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record IssueTokenResponse
{
    [JsonPropertyName("token")]
    public string? Token { get; init; }
}
