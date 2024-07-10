using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record RenderOutputResponse
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<RenderOutput> Results { get; init; } = new List<RenderOutput>();
}
