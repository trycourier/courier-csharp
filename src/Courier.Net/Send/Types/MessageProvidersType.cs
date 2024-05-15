using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class MessageProvidersType
{
    /// <summary>
    /// Provider specific overrides.
    /// </summary>
    [JsonPropertyName("override")]
    public Dictionary<string, object>? Override { get; init; }

    /// <summary>
    /// A JavaScript conditional expression to determine if the message should be sent
    /// through the channel. Has access to the data and profile object. For example,
    /// `data.name === profile.name`
    /// </summary>
    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("timeouts")]
    public int? Timeouts { get; init; }

    [JsonPropertyName("metadata")]
    public Metadata? Metadata { get; init; }
}
