using System.Text.Json.Serialization;

namespace Courier.Net;

public class IssueTokenResponse
{
    [JsonPropertyName("token")]
    public string? Token { get; init; }
}
