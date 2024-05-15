using System.Text.Json.Serialization;

namespace Courier.Net;

public class MergeProfileResponse
{
    [JsonPropertyName("status")]
    public string Status { get; init; }
}
