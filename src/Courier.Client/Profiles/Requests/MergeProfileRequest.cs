using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record MergeProfileRequest
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object> Profile { get; init; } = new Dictionary<string, object>();
}
