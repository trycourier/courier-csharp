using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record IssueTokenResponse
{
    [JsonPropertyName("token")]
    public string? Token { get; init; }
}
