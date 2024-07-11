using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record Channel
{
    /// <summary>
    /// Id of the brand that should be used for rendering the message.
    /// If not specified, the brand configured as default brand will be used.
    /// </summary>
    [JsonPropertyName("brand_id")]
    public string? BrandId { get; init; }

    /// <summary>
    /// A list of providers enabled for this channel. Courier will select
    /// one provider to send through unless routing_method is set to all.
    /// </summary>
    [JsonPropertyName("providers")]
    public IEnumerable<string>? Providers { get; init; }

    /// <summary>
    /// The method for selecting the providers to send the message with.
    /// Single will send to one of the available providers for this channel,
    /// all will send the message through all channels. Defaults to `single`.
    /// </summary>
    [JsonPropertyName("routing_method")]
    public RoutingMethod? RoutingMethod { get; init; }

    /// <summary>
    /// A JavaScript conditional expression to determine if the message should
    /// be sent through the channel. Has access to the data and profile object.
    /// For example, `data.name === profile.name`
    /// </summary>
    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("timeouts")]
    public Timeouts? Timeouts { get; init; }

    /// <summary>
    /// Channel specific overrides.
    /// </summary>
    [JsonPropertyName("override")]
    public Dictionary<string, object>? Override { get; init; }

    [JsonPropertyName("metadata")]
    public ChannelMetadata? Metadata { get; init; }
}
