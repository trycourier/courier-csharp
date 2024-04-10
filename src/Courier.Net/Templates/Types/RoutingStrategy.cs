using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class RoutingStrategy
{
    /// <summary>
    /// The method for selecting channels to send the message with. Value can be either 'single' or 'all'. If not provided will default to 'single'
    /// </summary>
    [JsonPropertyName("method")]
    public RoutingStrategyMethod Method { get; init; }

    /// <summary>
    /// An array of valid channel identifiers (like email, push, sms, etc.) and additional routing nodes.
    /// </summary>
    [JsonPropertyName("channels")]
    public List<string> Channels { get; init; }
}
