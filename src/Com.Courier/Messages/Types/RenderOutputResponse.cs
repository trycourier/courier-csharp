using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record RenderOutputResponse
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<RenderOutput> Results { get; init; } = new List<RenderOutput>();
}
