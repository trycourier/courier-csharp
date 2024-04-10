using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class RenderOutputResponse
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    [JsonPropertyName("results")]
    public List<RenderOutput> Results { get; init; }
}
