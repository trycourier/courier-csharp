using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record MessageProvidersType
{
    /// <summary>
    /// Provider specific overrides.
    /// </summary>
    [JsonPropertyName("override")]
    public Dictionary<string, object?>? Override { get; set; }

    /// <summary>
    /// A JavaScript conditional expression to determine if the message should
    /// be sent through the provider. Has access to the data and profile object.
    /// Only applies when a custom routing strategy is defined.
    /// For example, `data.name === profile.name`
    /// </summary>
    [JsonPropertyName("if")]
    public string? If { get; set; }

    [JsonPropertyName("timeouts")]
    public int? Timeouts { get; set; }

    [JsonPropertyName("metadata")]
    public Metadata? Metadata { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
