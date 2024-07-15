using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record RenderOutputResponse
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<RenderOutput> Results { get; init; } = new List<RenderOutput>();
}
