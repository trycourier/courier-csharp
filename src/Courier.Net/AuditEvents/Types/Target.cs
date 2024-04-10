using System.Text.Json.Serialization;

namespace Courier.Net;

public class Target
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }
}
