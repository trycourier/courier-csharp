using System.Text.Json.Serialization;
using OneOf;

namespace Courier.Net;

public class Expiry
{
    /// <summary>
    /// An epoch timestamp or ISO8601 timestamp with timezone `(YYYY-MM-DDThh:mm:ss.sTZD)` that describes the time in which a message expires.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; init; }

    /// <summary>
    /// A duration in the form of milliseconds or an ISO8601 Duration format (i.e. P1DT4H).
    /// </summary>
    [JsonPropertyName("expires_in")]
    public OneOf<string, int> ExpiresIn { get; init; }
}
