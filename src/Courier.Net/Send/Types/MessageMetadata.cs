using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class MessageMetadata
{
    /// <summary>
    /// An arbitrary string to tracks the event that generated this request (e.g. 'signup').
    /// </summary>
    [JsonPropertyName("event")]
    public string? Event { get; init; }

    /// <summary>
    /// An array of up to 9 tags you wish to associate with this request (and corresponding messages) for later analysis. Individual tags cannot be more than 30 characters in length.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string>? Tags { get; init; }

    /// <summary>
    /// Identify the campaign that refers traffic to a specific website, and attributes the browser's website session.
    /// </summary>
    [JsonPropertyName("utm")]
    public Utm? Utm { get; init; }

    /// <summary>
    /// A unique ID used to correlate this request to processing on your servers. Note: Courier does not verify the uniqueness of this ID.
    /// </summary>
    [JsonPropertyName("trace_id")]
    public string? TraceId { get; init; }
}
