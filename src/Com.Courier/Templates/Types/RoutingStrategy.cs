using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record RoutingStrategy
{
    /// <summary>
    /// The method for selecting channels to send the message with. Value can be either 'single' or 'all'. If not provided will default to 'single'
    /// </summary>
    [JsonPropertyName("method")]
    public required RoutingStrategyMethod Method { get; init; }

    /// <summary>
    /// An array of valid channel identifiers (like email, push, sms, etc.) and additional routing nodes.
    /// </summary>
    [JsonPropertyName("channels")]
    public IEnumerable<string> Channels { get; init; } = new List<string>();
}
