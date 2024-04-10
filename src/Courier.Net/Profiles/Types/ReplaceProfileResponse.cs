using System.Text.Json.Serialization;

namespace Courier.Net;

public class ReplaceProfileResponse
{
    [JsonPropertyName("status")]
    public string Status { get; init; }
}
