using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Channel
{
    /// <summary>
    /// Id of the brand that should be used for rendering the message.
    /// If not specified, the brand configured as default brand will be used.
    /// </summary>
    [JsonPropertyName("brand_id")]
    public string? BrandId { get; set; }

    /// <summary>
    /// A list of providers enabled for this channel. Courier will select
    /// one provider to send through unless routing_method is set to all.
    /// </summary>
    [JsonPropertyName("providers")]
    public IEnumerable<string>? Providers { get; set; }

    /// <summary>
    /// The method for selecting the providers to send the message with.
    /// Single will send to one of the available providers for this channel,
    /// all will send the message through all channels. Defaults to `single`.
    /// </summary>
    [JsonPropertyName("routing_method")]
    public RoutingMethod? RoutingMethod { get; set; }

    /// <summary>
    /// A JavaScript conditional expression to determine if the message should
    /// be sent through the channel. Has access to the data and profile object.
    /// Only applies when a custom routing strategy is defined.
    /// For example, `data.name === profile.name`
    /// </summary>
    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("timeouts")]
    public Timeouts? Timeouts { get; set; }

    /// <summary>
    /// Channel specific overrides.
    /// </summary>
    [JsonPropertyName("override")]
    public Dictionary<string, object?>? Override { get; set; }

    [JsonPropertyName("metadata")]
    public ChannelMetadata? Metadata { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
