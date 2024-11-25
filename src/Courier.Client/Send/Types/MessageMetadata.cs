using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record MessageMetadata
{
    /// <summary>
    /// An arbitrary string to tracks the event that generated this request (e.g. 'signup').
    /// </summary>
    [JsonPropertyName("event")]
    public string? Event { get; set; }

    /// <summary>
    /// An array of up to 9 tags you wish to associate with this request (and corresponding messages) for later analysis. Individual tags cannot be more than 30 characters in length.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <summary>
    /// Identify the campaign that refers traffic to a specific website, and attributes the browser's website session.
    /// </summary>
    [JsonPropertyName("utm")]
    public Utm? Utm { get; set; }

    /// <summary>
    /// A unique ID used to correlate this request to processing on your servers. Note: Courier does not verify the uniqueness of this ID.
    /// </summary>
    [JsonPropertyName("trace_id")]
    public string? TraceId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
