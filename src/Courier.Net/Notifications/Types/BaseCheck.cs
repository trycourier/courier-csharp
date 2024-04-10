using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BaseCheck
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("status")]
    public CheckStatus Status { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }
}
