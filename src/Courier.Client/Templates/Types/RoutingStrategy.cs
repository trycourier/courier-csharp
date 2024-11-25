using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record RoutingStrategy
{
    /// <summary>
    /// The method for selecting channels to send the message with. Value can be either 'single' or 'all'. If not provided will default to 'single'
    /// </summary>
    [JsonPropertyName("method")]
    public required RoutingStrategyMethod Method { get; set; }

    /// <summary>
    /// An array of valid channel identifiers (like email, push, sms, etc.) and additional routing nodes.
    /// </summary>
    [JsonPropertyName("channels")]
    public IEnumerable<string> Channels { get; set; } = new List<string>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
